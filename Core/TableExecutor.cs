using IntegracaoCepsaBrasil.Data;
using IntegracaoCepsaBrasil.Data.Models;
using IntegracaoCepsaBrasil.Data.Repository;
using IntegracaoCepsaBrasil.Proxy.CEPSA;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Diagnostics;

namespace IntegracaoCepsaBrasil.Core;

public class TableExecutor
{
    private readonly ICEPSARESTRepository _cepsaRepository;
    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly DbContextOptions<CEPSADbContext> _dbContextOptions;

    public TableExecutor(
        ICEPSARESTRepository cepsaRepository,
        IServiceScopeFactory serviceScopeFactory,
        DbContextOptions<CEPSADbContext> dbContextOptions)
    {
        _cepsaRepository = cepsaRepository;
        _serviceScopeFactory = serviceScopeFactory;
        _dbContextOptions = dbContextOptions;
    }

    public async Task<List<ExecutionResult>> ExecuteAsync(string? tableName, DateTime date)
    {
        var results = new List<ExecutionResult>();
        var dataRepository = new CEPSADataRepository(_dbContextOptions);

        var tablesToExecute = tableName == null || tableName.Equals("AllTables", StringComparison.OrdinalIgnoreCase)
            ? new[] { "DatosSindicales", "EmpJob", "PerAddress", "PerEmail", "PerPerson", "PerPersonal", "PerPhone" }
            : new[] { tableName };

        foreach (var table in tablesToExecute)
        {
            var result = await ExecuteTableAsync(table, date, dataRepository);
            results.Add(result);

            using var scope = _serviceScopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CEPSADbContext>();
            await SaveExecutionLog(dbContext, result);
        }

        return results;
    }

    private async Task<ExecutionResult> ExecuteTableAsync(string tableName, DateTime date, CEPSADataRepository dataRepository)
    {
        var stopwatch = Stopwatch.StartNew();

        try
        {
            Log.Information("► Iniciando: {TableName}", tableName);

            int recordsImported = tableName switch
            {
                "DatosSindicales" => await ImportDatosSindicales(dataRepository, date),
                "EmpJob" => await ImportEmpJob(dataRepository, date),
                "PerAddress" => await ImportPerAddress(dataRepository, date),
                "PerEmail" => await ImportPerEmail(dataRepository, date),
                "PerPerson" => await ImportPerPerson(dataRepository, date),
                "PerPersonal" => await ImportPerPersonal(dataRepository, date),
                "PerPhone" => await ImportPerPhone(dataRepository, date),
                _ => throw new ArgumentException($"Tabela desconhecida: {tableName}")
            };

            stopwatch.Stop();
            Log.Information("✓ Concluído: {TableName} - {Records} registros em {Duration}ms", tableName, recordsImported, stopwatch.ElapsedMilliseconds);

            return new ExecutionResult
            {
                ExecutionDateTime = DateTime.Now,
                TableName = tableName,
                RequestedDate = date,
                RecordsImported = recordsImported,
                DurationMs = stopwatch.ElapsedMilliseconds,
                Status = "Success"
            };
        }
        catch (Exception ex)
        {
            stopwatch.Stop();
            Log.Error(ex, "✗ Erro ao importar {TableName}", tableName);

            return new ExecutionResult
            {
                ExecutionDateTime = DateTime.Now,
                TableName = tableName,
                RequestedDate = date,
                RecordsImported = 0,
                DurationMs = stopwatch.ElapsedMilliseconds,
                Status = "Failed",
                ErrorMessage = ex.Message
            };
        }
    }

    private async Task SaveExecutionLog(CEPSADbContext dbContext, ExecutionResult result)
    {
        var log = new ExecutionLog
        {
            ExecutionDateTime = result.ExecutionDateTime,
            TableName = result.TableName,
            RequestedDate = result.RequestedDate,
            RecordsImported = result.RecordsImported,
            DurationMs = result.DurationMs,
            Status = result.Status,
            ErrorMessage = result.ErrorMessage
        };

        dbContext.ExecutionLogs.Add(log);
        await dbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Executa uma operação com retry simples em caso de timeout ou erro transitório
    /// </summary>
    private async Task<T?> ExecuteWithRetry<T>(Func<Task<T?>> action, string operationName, int maxRetries = 2)
    {
        for (int attempt = 1; attempt <= maxRetries + 1; attempt++)
        {
            try
            {
                return await action();
            }
            catch (TaskCanceledException) when (attempt <= maxRetries)
            {
                var delay = TimeSpan.FromSeconds(5 * attempt);
                Log.Warning("⚠️ Timeout em {Operation} - Tentativa {Attempt}/{MaxAttempts}. Aguardando {Delay}s...",
                    operationName, attempt, maxRetries + 1, delay.TotalSeconds);
                await Task.Delay(delay);
            }
            catch (HttpRequestException) when (attempt <= maxRetries)
            {
                var delay = TimeSpan.FromSeconds(5 * attempt);
                Log.Warning("⚠️ Erro de rede em {Operation} - Tentativa {Attempt}/{MaxAttempts}. Aguardando {Delay}s...",
                    operationName, attempt, maxRetries + 1, delay.TotalSeconds);
                await Task.Delay(delay);
            }
        }

        // Última tentativa sem catch
        return await action();
    }

    private async Task<int> ImportDatosSindicales(CEPSADataRepository repository, DateTime date)
    {
        var data = await ExecuteWithRetry(
            () => _cepsaRepository.GetDatosSindicales(date, CancellationToken.None),
            "GetDatosSindicales");

        if (data?.CustDatosSindicalesBRA == null) return 0;

        var entities = data.CustDatosSindicalesBRA.Select(x => (DatosSindicales)x);
        return await repository.ImportDatosSindicales(entities, date, CancellationToken.None);
    }

    private async Task<int> ImportEmpJob(CEPSADataRepository repository, DateTime date)
    {
        var data = await ExecuteWithRetry(
            () => _cepsaRepository.GetEmpJob(date, CancellationToken.None),
            "GetEmpJob");

        if (data?.EmpJob == null) return 0;

        var entities = data.EmpJob.Where(x => x.Company == "00S8").Select(x => (EmpJob)x);
        return await repository.ImportEmpJob(entities, date, CancellationToken.None);
    }

    private async Task<int> ImportPerAddress(CEPSADataRepository repository, DateTime date)
    {
        var data = await ExecuteWithRetry(
            () => _cepsaRepository.GetPerAddressDEFLT(date, CancellationToken.None),
            "GetPerAddressDEFLT");

        if (data?.PerAddressDEFLT == null) return 0;

        var entities = data.PerAddressDEFLT.Where(x => x.Company == "00S8").Select(x => (PerAddress)x);
        return await repository.ImportPerAddress(entities, date, CancellationToken.None);
    }

    private async Task<int> ImportPerEmail(CEPSADataRepository repository, DateTime date)
    {
        var data = await ExecuteWithRetry(
            () => _cepsaRepository.GetPerEmail(date, CancellationToken.None),
            "GetPerEmail");

        if (data?.PerEmail?.PerEmail == null) return 0;

        var entities = data.PerEmail.PerEmail.Where(x => x.Company?.Equals("00S8") == true).Select(x => (PerEmail)x);
        return await repository.ImportPerEmail(entities, date, CancellationToken.None);
    }

    private async Task<int> ImportPerPerson(CEPSADataRepository repository, DateTime date)
    {
        var data = await ExecuteWithRetry(
            () => _cepsaRepository.GetPerPerson(date, CancellationToken.None),
            "GetPerPerson");

        if (data?.PerPerson == null) return 0;

        var entities = data.PerPerson.Where(x => x.Company == "00S8").Select(x => (PerPerson)x);
        return await repository.ImportPerPerson(entities, date, CancellationToken.None);
    }

    private async Task<int> ImportPerPersonal(CEPSADataRepository repository, DateTime date)
    {
        var data = await ExecuteWithRetry(
            () => _cepsaRepository.GetPerPersonal(date, CancellationToken.None),
            "GetPerPersonal");

        if (data?.Root == null) return 0;

        var entities = data.Root.Where(x => x.Company == "00S8").Select(x => (PerPersonal)x);
        return await repository.ImportPerPersonal(entities, date, CancellationToken.None);
    }

    private async Task<int> ImportPerPhone(CEPSADataRepository repository, DateTime date)
    {
        var data = await ExecuteWithRetry(
            () => _cepsaRepository.GetPerPhone(date, CancellationToken.None),
            "GetPerPhone");

        if (data?.PerPhone?.PerPhoneArray == null) return 0;

        var entities = data.PerPhone.PerPhoneArray.Select(x => (PerPhone)x);
        return await repository.ImportPerPhone(entities, date, CancellationToken.None);
    }
}

public class ExecutionResult
{
    public DateTime ExecutionDateTime { get; set; }
    public string TableName { get; set; } = string.Empty;
    public DateTime RequestedDate { get; set; }
    public int RecordsImported { get; set; }
    public long DurationMs { get; set; }
    public string Status { get; set; } = string.Empty;
    public string? ErrorMessage { get; set; }
}