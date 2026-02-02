namespace IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;

public class CEPSAErrorResponse
{
    public int Status { get; set; }
    public string Error { get; set; } = default!;
    public IEnumerable<string>? Info { get; set; }
    public string? Message { get; set; }
    public DateTime? Timestamp { get; set; }
}
