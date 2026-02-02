using Newtonsoft.Json;

namespace IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;

public class Resultadocust_DatosSindicalesBRA
{
    [JsonProperty("cust_DatosSindicalesBRA")]
    public List<CustDatosSindicalesBRAArray>? CustDatosSindicalesBRA
    {
        get; set;
    }
}

public class CustDatosSindicalesBRAArray
{
    [JsonProperty("cust_CodigoDoSindicato")]
    public string? CustCodigoDoSindicato { get; set; }

    [JsonProperty("cust_IndicadorDeSindicalizado")]
    public string? CustIndicadorDeSindicalizado { get; set; }

    [JsonProperty("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [JsonProperty("externalCode")]
    public string? ExternalCode { get; set; }
}
