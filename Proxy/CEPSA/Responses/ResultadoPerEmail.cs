using Newtonsoft.Json;

namespace IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;

public class ResultadoPerEmail
{
    [JsonProperty("PerEmail")]
    public PerEmailObject? PerEmail { get; set; }
}

public class PerEmailObject
{
    [JsonProperty("PerEmail")]
    public List<PerEmailArray>? PerEmail { get; set; }
}

public class PerEmailArray
{
    [JsonProperty("emailAddress")]
    public string? EmailAddress { get; set; }

    [JsonProperty("emailType")]
    public string? EmailType { get; set; }

    [JsonProperty("personIdExternal")]
    public string? PersonIdExternal { get; set; }

    [JsonProperty("company")]
    public string? Company { get; set; }

    [JsonProperty("userId")]
    public string? UserId { get; set; }
}