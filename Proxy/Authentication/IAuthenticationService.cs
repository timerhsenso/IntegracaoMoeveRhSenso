namespace IntegracaoCepsaBrasil.Proxy.Authentication;

public interface IAuthenticationService
{
    Task<string?> GetTokenAsync();
}
