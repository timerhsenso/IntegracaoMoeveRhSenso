using Newtonsoft.Json;

namespace IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;

public class ResultadoPerPerson
{
    [JsonProperty("root")]
    public List<PerPersonArray>? PerPerson { get; set; }
}

public class PerPersonArray
{
    [JsonProperty("personIdExternal")]
    public string? PersonIdExternal { get; set; }

    [JsonProperty("customString4")]
    public string? CustomString4 { get; set; }

    [JsonProperty("dateOfBirth")]
    public string? DateOfBirth { get; set; }

    [JsonProperty("endDate")]
    public string? EndDate { get; set; }

    [JsonProperty("company")]
    public string? Company { get; set; }

    [JsonProperty("startDate")]
    public string? StartDate { get; set; }

    [JsonProperty("lastModifiedOn")]
    public string? LastModifiedOn { get; set; }
}