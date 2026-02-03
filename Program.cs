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
        // ✅ VERIFICAR --help ANTES DE TUDO
        if (args.Any(a => a.Equals("--help", StringComparison.OrdinalIgnoreCase) ||
                          a.Equals("-h", StringComparison.OrdinalIgnoreCase) ||
                          a.Equals("/?", StringComparison.OrdinalIgnoreCase)))
        {
            ShowHelp();
            return 0;
        }

        // ✅ VERIFICAR --checkdb ANTES DE TUDO
        if (args.Any(a => a.Equals("--checkdb", StringComparison.OrdinalIgnoreCase)))
        {
            return await CheckDatabaseConnection();
        }

        try
        {
            var arguments = ArgumentParser.Parse(args);

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

    private static async Task<int> CheckDatabaseConnection()
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              VERIFICAÇÃO DE CONEXÃO COM BANCO DE DADOS                       ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
        Console.WriteLine();

        try
        {
            // Configurar apenas o essencial
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true);

            _configuration = builder.Build();

            var connectionString = _configuration.GetConnectionString("CEPSA");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("❌ Connection String 'CEPSA' não encontrada no appsettings.json");
                Console.ResetColor();
                return 1;
            }

            Console.WriteLine("📋 Connection String encontrada:");
            Console.WriteLine($"   {MaskConnectionString(connectionString)}");
            Console.WriteLine();

            // Criar DbContext
            var services = new ServiceCollection();
            services.AddDbContext<CEPSADbContext>(options =>
                options.UseSqlServer(connectionString));

            _serviceProvider = services.BuildServiceProvider();

            using var scope = _serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<CEPSADbContext>();

            // Teste 1: Conectar ao banco
            Console.Write("🔌 Testando conexão com o banco... ");
            var stopwatch = Stopwatch.StartNew();
            var canConnect = await dbContext.Database.CanConnectAsync();
            stopwatch.Stop();

            if (!canConnect)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"FALHOU ({stopwatch.ElapsedMilliseconds}ms)");
                Console.ResetColor();
                return 1;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"OK ({stopwatch.ElapsedMilliseconds}ms)");
            Console.ResetColor();

            // Teste 2: Executar query simples
            Console.Write("📊 Executando SELECT 1... ");
            stopwatch.Restart();
            await dbContext.Database.ExecuteSqlRawAsync("SELECT 1");
            stopwatch.Stop();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"OK ({stopwatch.ElapsedMilliseconds}ms)");
            Console.ResetColor();

            // Teste 3: Verificar migrations
            Console.Write("🔄 Verificando migrations... ");
            var pendingMigrations = await dbContext.Database.GetPendingMigrationsAsync();
            var appliedMigrations = await dbContext.Database.GetAppliedMigrationsAsync();

            if (pendingMigrations.Any())
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"PENDENTE ({pendingMigrations.Count()} migration(s))");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("   Migrations pendentes:");
                foreach (var migration in pendingMigrations)
                {
                    Console.WriteLine($"   - {migration}");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"OK ({appliedMigrations.Count()} migration(s) aplicada(s))");
                Console.ResetColor();
            }

            // Teste 4: Verificar tabelas principais
            Console.WriteLine();
            Console.WriteLine("📁 Verificando tabelas principais:");

            var tables = new[]
            {
                "sapsf_DatosSindicales",
                "sapsf_EmpJob",
                "sapsf_PerAddress",
                "sapsf_PerEmail",
                "sapsf_PerPerson",
                "sapsf_PerPersonal",
                "sapsf_PerPhone",
                "IntegrationExecutionLog"
            };

            var allTablesExist = true;
            var connection = dbContext.Database.GetDbConnection();
            await connection.OpenAsync();

            foreach (var tableName in tables)
            {
                try
                {
                    using var command = connection.CreateCommand();
                    command.CommandText = $"SELECT COUNT(*) FROM [{tableName}]";
                    var result = await command.ExecuteScalarAsync();
                    var count = Convert.ToInt32(result);

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"   ✓ {tableName,-30} {count,10:N0} registro(s)");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"   ✗ {tableName,-30} ERRO: {ex.Message}");
                    Console.ResetColor();
                    allTablesExist = false;
                }
            }

            await connection.CloseAsync();

            Console.WriteLine();
            Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════╗");

            if (allTablesExist && !pendingMigrations.Any())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("║                   ✓ BANCO DE DADOS CONFIGURADO CORRETAMENTE                 ║");
                Console.ResetColor();
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
                Console.WriteLine();
                return 0;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("║              ⚠️  BANCO DE DADOS COM PROBLEMAS - VERIFIQUE ACIMA              ║");
                Console.ResetColor();
                Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
                Console.WriteLine();

                if (pendingMigrations.Any())
                {
                    Console.WriteLine("💡 Execute o programa normalmente para aplicar as migrations pendentes.");
                    Console.WriteLine();
                }

                return 1;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("❌ ERRO AO VERIFICAR BANCO DE DADOS:");
            Console.WriteLine($"   {ex.Message}");
            Console.ResetColor();
            Console.WriteLine();

            if (ex.InnerException != null)
            {
                Console.WriteLine("Detalhes:");
                Console.WriteLine($"   {ex.InnerException.Message}");
                Console.WriteLine();
            }

            return 1;
        }
    }

    private static string MaskConnectionString(string connectionString)
    {
        // Mascara senha na connection string para exibição
        var parts = connectionString.Split(';');
        var masked = parts.Select(part =>
        {
            if (part.Trim().StartsWith("Password=", StringComparison.OrdinalIgnoreCase) ||
                part.Trim().StartsWith("Pwd=", StringComparison.OrdinalIgnoreCase))
            {
                var key = part.Split('=')[0];
                return $"{key}=********";
            }
            return part;
        });

        return string.Join(";", masked);
    }

    private static void ShowHelp()
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    INTEGRAÇÃO CEPSA BRASIL - AJUDA                           ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine("USO:");
        Console.WriteLine("  IntegracaoCepsaBrasil.exe [TableName] [Date]");
        Console.WriteLine();
        Console.WriteLine("PARÂMETROS:");
        Console.WriteLine("  TableName    Nome da tabela a importar (opcional)");
        Console.WriteLine("               Valores aceitos:");
        Console.WriteLine("                 - AllTables (padrão se omitido)");
        Console.WriteLine("                 - DatosSindicales");
        Console.WriteLine("                 - EmpJob");
        Console.WriteLine("                 - PerAddressDEFLT");
        Console.WriteLine("                 - PerEmail");
        Console.WriteLine("                 - PerPerson");
        Console.WriteLine("                 - PerPersonal");
        Console.WriteLine("                 - PerPhone");
        Console.WriteLine();
        Console.WriteLine("  Date         Data de referência no formato DD/MM/YYYY (opcional)");
        Console.WriteLine("               Padrão: Data atual");
        Console.WriteLine();
        Console.WriteLine("EXEMPLOS:");
        Console.WriteLine("  IntegracaoCepsaBrasil.exe");
        Console.WriteLine("    Importa todas as tabelas com a data de hoje");
        Console.WriteLine();
        Console.WriteLine("  IntegracaoCepsaBrasil.exe AllTables 01/01/2026");
        Console.WriteLine("    Importa todas as tabelas com a data 01/01/2026");
        Console.WriteLine();
        Console.WriteLine("  IntegracaoCepsaBrasil.exe PerEmail");
        Console.WriteLine("    Importa apenas a tabela PerEmail com a data de hoje");
        Console.WriteLine();
        Console.WriteLine("  IntegracaoCepsaBrasil.exe EmpJob 15/12/2025");
        Console.WriteLine("    Importa apenas a tabela EmpJob com a data 15/12/2025");
        Console.WriteLine();
        Console.WriteLine("OPÇÕES:");
        Console.WriteLine("  --help, -h, /?    Exibe esta ajuda");
        Console.WriteLine("  --checkdb         Verifica conexão com banco de dados");
        Console.WriteLine();
        Console.WriteLine("CÓDIGOS DE RETORNO:");
        Console.WriteLine("  0 - Sucesso");
        Console.WriteLine("  1 - Erro de validação ou conexão com banco");
        Console.WriteLine("  3 - Sucesso parcial (uma ou mais tabelas falharam)");
        Console.WriteLine("  4 - Erro crítico");
        Console.WriteLine();
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