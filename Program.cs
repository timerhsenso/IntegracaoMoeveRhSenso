using IntegracaoCepsaBrasil.Core;
using IntegracaoCepsaBrasil.Data;
using IntegracaoCepsaBrasil.Data.Repository;
using IntegracaoCepsaBrasil.Proxy.Authentication;
using IntegracaoCepsaBrasil.Proxy.CEPSA;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System.Diagnostics;

namespace IntegracaoCepsaBrasil;

public class Program
{
    private static IConfiguration _configuration = null!;
    private static IServiceProvider _serviceProvider = null!;

    public static async Task<int> Main(string[] args)
    {
        try
        {
            // ✅ PRIMEIRA COISA: VERIFICAR --help (SEM TOCAR EM NADA)
            var arguments = ArgumentParser.Parse(args);

            // ✅ SÓ CONFIGURA O RESTO SE NÃO FOR --help
            ConfigureLogging();
            ConfigureServices();
            await EnsureDatabaseMigrated();

            var executor = _serviceProvider.GetRequiredService<TableExecutor>();

            Log.Information("╔══════════════════════════════════════════════════════════════╗");
            Log.Information("║           INTEGRAÇÃO CEPSA BRASIL - INICIANDO                ║");
            Log.Information("╚══════════════════════════════════════════════════════════════╝");
            Log.Information("Tabelas: {Tables}", arguments.TableName ?? "TODAS");
            Log.Information("Data: {Date:dd/MM/yyyy}", arguments.Date);
            Log.Information("");

            var stopwatch = Stopwatch.StartNew();
            var results = await executor.ExecuteAsync(arguments.TableName, arguments.Date);
            stopwatch.Stop();

            PrintFinalReport(results, arguments.Date, stopwatch.Elapsed);

            var hasErrors = results.Any(r => r.Status == "Failed");
            return hasErrors ? 3 : 0;
        }
        catch (ArgumentException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ ERRO: {ex.Message}\n");
            Console.ResetColor();
            Console.WriteLine("Use --help para ver todas as opções disponíveis.");
            Console.WriteLine();
            return 1;
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "Erro crítico na execução");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ ERRO CRÍTICO: {ex.Message}");
            Console.ResetColor();
            return 4;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }

    private static void ConfigureLogging()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/integration-.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();
    }

    private static void ConfigureServices()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true);

        _configuration = builder.Build();

        var services = new ServiceCollection();

        // DbContext
        services.AddDbContext<CEPSADbContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("CEPSA")));

        // Repositories
        services.AddScoped<ICEPSADataRepository, CEPSADataRepository>();

        // Authentication
        var authConfig = _configuration.GetSection("Authentication").Get<AuthenticationConfiguration>()!;
        services.AddSingleton(authConfig);
        services.AddSingleton<IAuthenticationService, AuthenticationService>();
        services.AddTransient<AuthenticationHandler>();

        // HTTP Clients
        var apiConfig = _configuration.GetSection("APIConfiguration").Get<Dictionary<string, string>>()!;

        services.AddHttpClient("AuthenticationRESTHttpClient", client =>
        {
            client.BaseAddress = new Uri(apiConfig["Authentication"]);
            client.Timeout = TimeSpan.FromSeconds(30);
        });

        services.AddHttpClient("CEPSARESTHttpClient", client =>
        {
            var baseUrl = apiConfig["CEPSA"].Split(';')[0];
            client.BaseAddress = new Uri(baseUrl);
            client.Timeout = TimeSpan.FromMinutes(3);
        })
        .AddHttpMessageHandler<AuthenticationHandler>();

        // CEPSA Repository
        services.AddScoped<ICEPSARESTRepository, CEPSARESTRepository>();

        // Core
        services.AddScoped<TableExecutor>();
        services.AddLogging(builder => builder.AddSerilog());

        _serviceProvider = services.BuildServiceProvider();
    }

    private static async Task EnsureDatabaseMigrated()
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CEPSADbContext>();

        var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
        if (pendingMigrations.Any())
        {
            Log.Information("Aplicando {Count} migration(s) pendente(s)...", pendingMigrations.Count());
            await dbContext.Database.MigrateAsync();
            Log.Information("✓ Migrations aplicadas com sucesso");
        }
    }

    private static void PrintFinalReport(List<ExecutionResult> results, DateTime requestedDate, TimeSpan totalDuration)
    {
        var totalRecords = results.Sum(r => r.RecordsImported);
        var successCount = results.Count(r => r.Status == "Success");
        var failedCount = results.Count(r => r.Status == "Failed");

        Console.WriteLine();
        Log.Information("╔══════════════════════════════════════════════════════════════════════════════╗");
        Log.Information("║               INTEGRAÇÃO CEPSA - EXECUÇÃO CONCLUÍDA                          ║");
        Log.Information("╠══════════════════════════════════════════════════════════════════════════════╣");
        Log.Information("║ Data Solicitada: {Date,-58} ║", requestedDate.ToString("dd/MM/yyyy"));
        Log.Information("║ Duração Total: {Duration,-60} ║", FormatDuration(totalDuration));
        Log.Information("╠══════════════════════════════════════════════════════════════════════════════╣");
        Log.Information("║ {0,-25} {1,-15} {2,-15} {3,-15} ║", "TABELA", "REGISTROS", "DURAÇÃO", "STATUS");
        Log.Information("╠══════════════════════════════════════════════════════════════════════════════╣");

        foreach (var result in results)
        {
            var status = result.Status == "Success" ? "✓" : "✗";
            var statusColor = result.Status == "Success" ? "OK" : "FALHA";
            Log.Information("║ {0,-25} {1,-15} {2,-15} {3,-15} ║",
                result.TableName,
                result.RecordsImported.ToString("N0"),
                FormatDuration(TimeSpan.FromMilliseconds(result.DurationMs)),
                $"{status} {statusColor}");
        }

        Log.Information("╠══════════════════════════════════════════════════════════════════════════════╣");
        Log.Information("║ TOTAL: {0,-15} {1,-15} {2,-15} {3}/{4} OK     ║",
            totalRecords.ToString("N0"),
            FormatDuration(totalDuration),
            "",
            successCount,
            results.Count);
        Log.Information("╚══════════════════════════════════════════════════════════════════════════════╝");

        if (failedCount > 0)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Log.Warning("\n⚠️  ATENÇÃO: {FailedCount} tabela(s) falharam. Verifique os logs para detalhes.", failedCount);
            Console.ResetColor();
        }
    }

    private static string FormatDuration(TimeSpan duration)
    {
        if (duration.TotalMinutes >= 1)
            return $"{duration.Minutes}min {duration.Seconds}s";
        if (duration.TotalSeconds >= 1)
            return $"{duration.TotalSeconds:F1}s";
        return $"{duration.TotalMilliseconds:F0}ms";
    }
}