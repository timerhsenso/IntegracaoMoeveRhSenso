using Newtonsoft.Json;

namespace IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;

public class ResultadoEmpJobDEFLT
{
    [JsonProperty("EmpJob")]
    public List<EmpJobArray>? EmpJob { get; set; }
}

public class EmpJobArray
{
    [JsonProperty("customString160")]
    public string? CustomString160 { get; set; }

    [JsonProperty("customString151")]
    public string? CustomString151 { get; set; }

    [JsonProperty("customString150")]
    public string? CustomString150 { get; set; }

    [JsonProperty("customString153")]
    public string? CustomString153 { get; set; }

    [JsonProperty("customString152")]
    public string? CustomString152 { get; set; }

    [JsonProperty("customString155")]
    public string? CustomString155 { get; set; }

    [JsonProperty("contractType")]
    public string? ContractType { get; set; }

    [JsonProperty("costCenter")]
    public string? CostCenter { get; set; }

    [JsonProperty("customString154")]
    public string? CustomString154 { get; set; }

    [JsonProperty("userId")]
    public string? UserId { get; set; }

    [JsonProperty("lastModifiedOn")]
    public string? LastModifiedOn { get; set; }

    [JsonProperty("workerCategory")]
    public string? WorkerCategory { get; set; }

    [JsonProperty("customString157")]
    public string? CustomString157 { get; set; }

    [JsonProperty("customString156")]
    public string? CustomString156 { get; set; }

    [JsonProperty("customString159")]
    public string? CustomString159 { get; set; }

    [JsonProperty("company")]
    public string? Company { get; set; }
}