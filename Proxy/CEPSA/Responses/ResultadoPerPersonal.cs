using Newtonsoft.Json;

namespace IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;

public class ResultadoPerPersonal
{
    [JsonProperty("root")]
    public List<PerPersonal>? Root { get; set; }
}

public class PerPersonal
{
    [JsonProperty("gender")]
    public string? Gender { get; set; }

    [JsonProperty("nationality")]
    public string? Nationality { get; set; }

    [JsonProperty("personIdExternal")]
    public string? PersonIdExternal { get; set; }

    [JsonProperty("customString2")]
    public string? CustomString2 { get; set; }

    [JsonProperty("customString7")]
    public string? CustomString7 { get; set; }

    [JsonProperty("startDate")]
    public DateTime? StartDate { get; set; }

    [JsonProperty("lastModifiedOn")]
    public DateTime? LastModifiedOn { get; set; }

    [JsonProperty("maritalStatus")]
    public string? MaritalStatus { get; set; }

    [JsonProperty("userId")]
    public string? UserId { get; set; }

    [JsonProperty("company")]
    public string? Company { get; set; }
}