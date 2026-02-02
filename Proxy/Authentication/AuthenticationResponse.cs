using Newtonsoft.Json;

namespace IntegracaoCepsaBrasil.Proxy.Authentication;

public class AuthenticationResponse
{
    [JsonProperty("access_token")]
    public string? AccessToken { get; set; }

    [JsonProperty("token_type")]
    public string? TokenType { get; set; }

    [JsonProperty("expires_in")]
    public int? ExpiresIn { get; set; }

    [JsonProperty("scope")]
    public string? Scope { get; set; }

    [JsonProperty("api_product_list")]
    public string? ApiProductList { get; set; }

    [JsonProperty("issued_at")]
    public long? IssuedAt { get; set; }
}
