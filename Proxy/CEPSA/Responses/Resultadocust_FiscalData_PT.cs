using Newtonsoft.Json;

namespace IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;

public class Resultadocust_FiscalData_PT
{
    [JsonProperty("cust_FiscalData_PT")]
    public List<CustFiscalDataPTArray>? CustFiscalDataPT { get; set; }
}

// Classe para os objetos dentro do array
public class CustFiscalDataPTArray
{
    [JsonProperty("cust_NTituloDeEleitor")]
    public string? CustNTituloDeEleitor { get; set; }

    [JsonProperty("cust_DTEmissaoDoTitulo")]
    public string? CustDTEmissaoDoTitulo { get; set; }

    [JsonProperty("cust_SecaoDoTituloDeEleitor")]
    public string? CustSecaoDoTituloDeEleitor { get; set; }

    [JsonProperty("cust_ZonaDoTituloDeEleitor")]
    public string? CustZonaDoTituloDeEleitor { get; set; }

    [JsonProperty("cust_UFDoTituloDeEleitor")]
    public string? CustUFDoTituloDeEleitor { get; set; }

    [JsonProperty("lastModifiedDateTime")]
    public string? LastModifiedDateTime { get; set; }

    [JsonProperty("externalCode")]
    public string? ExternalCode { get; set; }
}
