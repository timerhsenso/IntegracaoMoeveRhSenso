using Newtonsoft.Json;
using System.Text;

namespace IntegracaoCepsaBrasil.Proxy.Authentication;

public class AuthenticationService(AuthenticationConfiguration _config, IHttpClientFactory _httpClientFactory) : IAuthenticationService
{
    private readonly SemaphoreSlim _tokenRefreshLock = new(1, 1);
    private DateTime? _tokenExpiry;
    private string? _token;

    public async Task<string?> GetTokenAsync()
    {
        if (_token is not null && _tokenExpiry is not null && DateTime.UtcNow < _tokenExpiry)
        {
            return _token;
        }

        return await UpdateTokenAsync();
    }

    private async Task<string?> UpdateTokenAsync()
    {
        await _tokenRefreshLock.WaitAsync();

        try
        {
            if (_token is not null && _tokenExpiry is not null && DateTime.UtcNow < _tokenExpiry)
            {
                return _token;
            }

            (_token, _tokenExpiry) = await GetNewTokenAsync();

            return _token;
        }
        finally
        {
            _tokenRefreshLock.Release();
        }
    }

    private async Task<(string? Token, DateTime? ValidTo)> GetNewTokenAsync()
    {
        var payload = new Dictionary<string, string>
        {
            { "client_id", _config.ClientId },
            { "client_secret", _config.ClientSecret },
            { "grant_type", "client_credentials" }
        };

        var encodedPayload = new FormUrlEncodedContent(payload);

        var response = await PostAsync<AuthenticationResponse>("oauth/token", encodedPayload, true);

        if (response?.AccessToken is not null)
        {
            return (response.AccessToken, DateTime.UtcNow.AddSeconds(response.ExpiresIn!.Value));
        }

        return (null, null);
    }

    private async Task<Result?> PostAsync<Result>(string uri, HttpContent? content = null, bool ensureSuccessStatusCode = true, Dictionary<string, string>? headers = null)
        => await SendAsync<Result>(HttpMethod.Post, uri, ensureSuccessStatusCode, headers, null, content);

    private async Task<Result?> SendAsync<Result>(HttpMethod method, string uri, bool ensureSuccessStatusCode, Dictionary<string, string>? headers, object? payload, HttpContent? content)
    {
        var response = await ExecuteAsync(method, uri, ensureSuccessStatusCode, headers, payload, content);

        if (response.IsSuccessStatusCode)
        {
            var responseStr = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Result>(responseStr);
        }

        return default;
    }

    private async Task<HttpResponseMessage> ExecuteAsync(HttpMethod method, string uri, bool ensureSuccessStatusCode, Dictionary<string, string>? headers, object? payload, HttpContent? content)
    {
        using var httpClient = GetHttpClient();

        var request = new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri($"{httpClient.BaseAddress}{uri}"),
            Content = content
        };

        if ((method == HttpMethod.Post || method == HttpMethod.Patch) && (payload is not null))
        {
            request.Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");
        }

        if (headers is not null)
        {
            foreach (var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }
        }

        var response = await httpClient.SendAsync(request);

        if (ensureSuccessStatusCode)
        {
            response.EnsureSuccessStatusCode();
        }

        return response;
    }

    private HttpClient GetHttpClient()
    {
        return _httpClientFactory.CreateClient("AuthenticationRESTHttpClient");
    }
}