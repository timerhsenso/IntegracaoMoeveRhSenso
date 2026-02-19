namespace IntegracaoCepsaBrasil.Proxy.CEPSA;

/// <summary>
/// Configuração das rotas dos endpoints da API CEPSA (SAP SuccessFactors).
/// Os valores são carregados da seção "EndpointRoutes" do appsettings.json,
/// permitindo alteração sem recompilação do sistema.
/// 
/// Placeholder suportado:
///   {date} → será substituído pela data no formato yyyy-MM-dd em runtime.
/// 
/// Exemplo no appsettings.json:
///   "EndpointRoutes": {
///     "DatosSindicales": "v1/DatosSindicales?date={date}"
///   }
/// </summary>
public class EndpointRoutesConfiguration
{
    public string DatosSindicales { get; set; } = "v1/DatosSindicales?date={date}";
    public string FiscalData { get; set; } = "v1/FiscalData?date={date}";
    public string EmpJob { get; set; } = "v1/EmpJob?date={date}";
    public string PerAddressDEFLT { get; set; } = "v1/PerAddressDEFLT?date={date}";
    public string PerEmail { get; set; } = "v1/PerEmail?date={date}";
    public string PerPerson { get; set; } = "v1/PerPerson?date={date}";
    public string PerPersonal { get; set; } = "v1/PerPersonal?date={date}";
    public string PerPhone { get; set; } = "v1/PerPhone?date={date}";

    /// <summary>
    /// Resolve o placeholder {date} na rota com a data formatada yyyy-MM-dd.
    /// </summary>
    public static string Resolve(string routeTemplate, DateTime date)
        => routeTemplate.Replace("{date}", date.ToString("yyyy-MM-dd"));
}