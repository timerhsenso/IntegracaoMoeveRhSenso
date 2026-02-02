using System.Globalization;

namespace IntegracaoCepsaBrasil.Core;

public class ArgumentParser
{
    private static readonly string[] ValidTables = new[]
    {
        "DatosSindicales",
        "EmpJob",
        "PerAddress",
        "PerEmail",
        "PerPerson",
        "PerPersonal",
        "PerPhone",
        "AllTables"
    };

    public static ParsedArguments Parse(string[] args)
    {
        // ✅ Verificar se pediu help
        if (args.Length > 0 && (args[0] == "--help" || args[0] == "-h" || args[0] == "/?" || args[0] == "help"))
        {
            PrintHelp();
            Environment.Exit(0);
        }

        string? tableName = null;
        DateTime date = DateTime.Today;

        if (args.Length > 0)
        {
            tableName = args[0];

            if (!ValidTables.Contains(tableName, StringComparer.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    $"Tabela '{tableName}' inválida.\n" +
                    $"Use --help para ver todas as opções disponíveis.");
            }
        }

        if (args.Length > 1)
        {
            if (!DateTime.TryParseExact(args[1], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
            {
                throw new ArgumentException(
                    $"Data '{args[1]}' inválida.\n" +
                    $"Use o formato: dd/MM/yyyy (ex: 21/01/2026)");
            }
        }

        return new ParsedArguments
        {
            TableName = tableName,
            Date = date
        };
    }

    private static void PrintHelp()
    {
        Console.WriteLine();
        Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                  INTEGRAÇÃO CEPSA BRASIL - AJUDA                         ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
        Console.WriteLine();
        Console.WriteLine("DESCRIÇÃO:");
        Console.WriteLine("  Importa dados de RH da API CEPSA (SAP SuccessFactors) para SQL Server");
        Console.WriteLine();
        Console.WriteLine("USO:");
        Console.WriteLine("  IntegracaoCepsaBrasil.exe [TABELA] [DATA]");
        Console.WriteLine("  IntegracaoCepsaBrasil.exe --help");
        Console.WriteLine();
        Console.WriteLine("PARÂMETROS:");
        Console.WriteLine("  TABELA        Nome da tabela a importar (opcional)");
        Console.WriteLine("                Se omitido, importa todas as tabelas");
        Console.WriteLine();
        Console.WriteLine("  DATA          Data dos dados a importar no formato dd/MM/yyyy (opcional)");
        Console.WriteLine("                Se omitido, usa a data atual");
        Console.WriteLine();
        Console.WriteLine("TABELAS DISPONÍVEIS:");
        Console.WriteLine("  ┌────────────────────┬──────────────────────────────────────────────┐");
        Console.WriteLine("  │ Nome               │ Descrição                                    │");
        Console.WriteLine("  ├────────────────────┼──────────────────────────────────────────────┤");
        Console.WriteLine("  │ DatosSindicales    │ Dados sindicais dos funcionários             │");
        Console.WriteLine("  │ EmpJob             │ Informações de cargo e emprego               │");
        Console.WriteLine("  │ PerAddress         │ Endereços residenciais                       │");
        Console.WriteLine("  │ PerEmail           │ Endereços de e-mail                          │");
        Console.WriteLine("  │ PerPerson          │ Dados pessoais básicos                       │");
        Console.WriteLine("  │ PerPersonal        │ Dados pessoais detalhados                    │");
        Console.WriteLine("  │ PerPhone           │ Telefones de contato                         │");
        Console.WriteLine("  │ AllTables          │ Importa todas as tabelas acima               │");
        Console.WriteLine("  └────────────────────┴──────────────────────────────────────────────┘");
        Console.WriteLine();
        Console.WriteLine("EXEMPLOS:");
        Console.WriteLine();
        Console.WriteLine("  1. Importar todas as tabelas com data atual:");
        Console.WriteLine("     IntegracaoCepsaBrasil.exe");
        Console.WriteLine();
        Console.WriteLine("  2. Importar todas as tabelas de uma data específica:");
        Console.WriteLine("     IntegracaoCepsaBrasil.exe AllTables 01/01/2026");
        Console.WriteLine();
        Console.WriteLine("  3. Importar apenas PerEmail com data atual:");
        Console.WriteLine("     IntegracaoCepsaBrasil.exe PerEmail");
        Console.WriteLine();
        Console.WriteLine("  4. Importar apenas EmpJob de uma data específica:");
        Console.WriteLine("     IntegracaoCepsaBrasil.exe EmpJob 15/12/2025");
        Console.WriteLine();
        Console.WriteLine("  5. Exibir esta ajuda:");
        Console.WriteLine("     IntegracaoCepsaBrasil.exe --help");
        Console.WriteLine();
        Console.WriteLine("CÓDIGOS DE RETORNO:");
        Console.WriteLine("  0  = Sucesso (todas as tabelas importadas)");
        Console.WriteLine("  1  = Erro de validação de parâmetros");
        Console.WriteLine("  3  = Erro parcial (algumas tabelas falharam)");
        Console.WriteLine("  4  = Erro crítico (nenhuma tabela foi importada)");
        Console.WriteLine();
        Console.WriteLine("LOGS:");
        Console.WriteLine("  Os logs são salvos em: ./logs/integration-YYYYMMDD.txt");
        Console.WriteLine();
        Console.WriteLine("AGENDAMENTO (Windows Task Scheduler):");
        Console.WriteLine("  Programa: C:\\Caminho\\IntegracaoCepsaBrasil.exe");
        Console.WriteLine("  Argumentos: AllTables");
        Console.WriteLine("  Iniciar em: C:\\Caminho");
        Console.WriteLine();
        Console.WriteLine("MAIS INFORMAÇÕES:");
        Console.WriteLine("  Documentação: [URL da wiki/confluence]");
        Console.WriteLine("  Suporte: [email do time]");
        Console.WriteLine();
        Console.WriteLine("════════════════════════════════════════════════════════════════════════════");
        Console.WriteLine();
    }

    /// <summary>
    /// Retorna a lista de tabelas válidas (útil para testes)
    /// </summary>
    public static IReadOnlyList<string> GetValidTables() => ValidTables;
}

public class ParsedArguments
{
    public string? TableName { get; set; }
    public DateTime Date { get; set; }
}