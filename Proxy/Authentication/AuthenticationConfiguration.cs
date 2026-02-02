using System.Text.Json.Serialization;

namespace IntegracaoCepsaBrasil.Proxy.Authentication;

public class AuthenticationConfiguration
{
    public string ClientId { get; set; } = default!;

    public string ClientSecret { get; set; } = default!;

    public string GrantType { get; set; } = default!;
}
