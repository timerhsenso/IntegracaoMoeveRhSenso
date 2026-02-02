using System.Net.Http.Headers;

namespace IntegracaoCepsaBrasil.Proxy.Authentication;

public class AuthenticationHandler(IAuthenticationService _tokenService) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var token = await _tokenService.GetTokenAsync();

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

        return await base.SendAsync(request, cancellationToken);
    }
}
