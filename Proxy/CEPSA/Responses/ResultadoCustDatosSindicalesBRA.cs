using Newtonsoft.Json;

namespace IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;

public class ResultadoCustDatosSindicalesBRA
{
    [JsonProperty("PerPhone")]
    public PerPhone? PerPhone { get; set; }
}

public class PerPhone
{
    [JsonProperty("PerPhone")]
    public List<PerPhoneArray>? PerPhoneArray { get; set; }
}

public class PerPhoneArray
{
    [JsonProperty("personIdExernal")]
    public string? PersonIdExernal { get; set; }

    [JsonProperty("businessPhone")]
    public string? BusinessPhone { get; set; }

    [JsonProperty("personalPhone")]
    public string? PersonalPhone { get; set; }

    [JsonProperty("Extension")]
    public string? Extension { get; set; }

    [JsonProperty("AreaCode")]
    public string? AreaCode { get; set; }
}