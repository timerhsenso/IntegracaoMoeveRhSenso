using Newtonsoft.Json;

namespace IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;

public class ResultadoPerAddressDEFLT
{
    [JsonProperty("root")]
    public List<PerAddressDEFLTArray>? PerAddressDEFLT { get; set; }
}

public class PerAddressDEFLTArray
{
    [JsonProperty("zipCode")]
    public string? ZipCode { get; set; }

    [JsonProperty("address3")]
    public string? Address3 { get; set; }

    [JsonProperty("personIdExternal")]
    public string? PersonIdExternal { get; set; }

    [JsonProperty("company")]
    public string? Company { get; set; }

    [JsonProperty("userId")]
    public string? UserId { get; set; }

    [JsonProperty("address2")]
    public string? Address2 { get; set; }

    [JsonProperty("address1")]
    public string? Address1 { get; set; }

    [JsonProperty("address4")]
    public string? Address4 { get; set; }

    [JsonProperty("customString2")]
    public string? CustomString2 { get; set; }
}