using System.Net;
using System.Text;
using IntegracaoCepsaBrasil.Util.Extentions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace IntegracaoCepsaBrasil.Proxy.Common;

public abstract class BaseRESTRepository
{
    private readonly string _httpClientName;
    private IHttpClientFactory _httpClientFactory { get; }
    protected ILogger<BaseRESTRepository> _logger { get; init; }

    public BaseRESTRepository(IHttpClientFactory httpClientFactory, ILogger<BaseRESTRepository> logger)
    {
        var name = GetType().Name.Replace("Repository", string.Empty);
        _httpClientName = $"{name}HttpClient";
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    private HttpClient GetHttpClient()
    {
        return _httpClientFactory.CreateClient(_httpClientName);
    }

    private async Task<HttpResponseMessage> ExecuteAsync(HttpMethod method, string uri, bool ensureSuccessStatusCode, Dictionary<string, string>? headers, object? payload, CancellationToken? cancellationToken)
    {
        var httpClient = GetHttpClient();

        var baseAdress = httpClient.BaseAddress!.ToString();

        if (!baseAdress.EndsWith("/") && !uri.StartsWith("/"))
        {
            baseAdress += "/";
        }

        var request = new HttpRequestMessage
        {
            Method = method,
            RequestUri = new Uri($"{baseAdress}{uri}")
        };

        if (method == HttpMethod.Post || method == HttpMethod.Patch)
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

        HttpResponseMessage response;

        if (cancellationToken is not null)
        {
            response = await _logger.ProfileAsync($"{method} {request.RequestUri.AbsolutePath}", () => httpClient.SendAsync(request, cancellationToken.Value));
        }
        else
        {
            response = await _logger.ProfileAsync($"{method} {request.RequestUri.AbsolutePath}", () => httpClient.SendAsync(request));
        }

        if (ensureSuccessStatusCode)
        {
            response.EnsureSuccessStatusCode();
        }

        return response;
    }

    /// <summary>
    /// Corrige JSON malformado retornado pela API CEPSA em respostas de erro.
    /// 
    /// WORKAROUND DOCUMENTADO:
    /// A API CEPSA (SAP SuccessFactors) retorna JSON inválido em algumas respostas de erro.
    /// Exemplo de JSON malformado recebido:
    ///   "info": [
    ///     "The request failed due to an internal error."
    ///     "resource":"EmpJob"   ← FALTA VÍRGULA
    ///   ]
    /// 
    /// Este método aplica correções automáticas conhecidas.
    /// 
    /// STATUS: Bug reportado ao fornecedor em [DATA DO REPORT]
    /// TODO: Remover este workaround quando a API for corrigida
    /// </summary>
    private string FixMalformedJson(string json)
    {
        var originalJson = json;

        // Só aplica correções em respostas de erro
        if (!json.Contains("\"error\"") && !json.Contains("\"status\""))
        {
            return json;
        }

        // Fix 1: Adiciona vírgula faltante entre elementos do array
        // Pattern: "text."\n    "resource":"Value"
        // Corrige para: "text.",\n    "resource":"Value"
        var pattern1 = @"(\""[^\""]*\.\"")(\s*\n\s*)(\""resource\"":)";
        json = System.Text.RegularExpressions.Regex.Replace(json, pattern1, "$1,$2$3");

        // Fix 2: Converte key-value malformado em array para string única
        // Pattern: "resource":"FiscalData"
        // Corrige para: "resource:FiscalData"
        var pattern2 = @"\""resource\"":""([^\""]+)\""";
        json = System.Text.RegularExpressions.Regex.Replace(json, pattern2, "\"resource:$1\"");

        if (json != originalJson)
        {
            _logger.LogWarning("⚠️ JSON malformado detectado e corrigido automaticamente");
            _logger.LogWarning("📝 A API CEPSA precisa corrigir este bug. Exemplo do problema:");
            _logger.LogDebug("JSON original (primeiros 500 chars): {Original}",
                originalJson.Substring(0, Math.Min(500, originalJson.Length)));
        }

        return json;
    }

    public virtual async Task<Result?> SendAsync<Result>(HttpMethod method, string uri, bool ensureSuccessStatusCode, Dictionary<string, string>? headers, object? payload, CancellationToken? cancellationToken)
    {
        using var response = await ExecuteAsync(method, uri, ensureSuccessStatusCode, headers, payload, cancellationToken);

        if (response.IsSuccessStatusCode)
        {
            var responseStr = await response.Content.ReadAsStringAsync();

            try
            {
                // ✅ Aplica correções de JSON malformado antes de deserializar
                var fixedJson = FixMalformedJson(responseStr);
                return JsonConvert.DeserializeObject<Result>(fixedJson);
            }
            catch (JsonException ex)
            {
                _logger.LogError("❌ Erro ao deserializar resposta de {Method} {Uri}", method, uri);
                _logger.LogError("Erro: {Message}", ex.Message);
                _logger.LogError("Conteúdo: {Response}", responseStr.Substring(0, Math.Min(1000, responseStr.Length)));
                throw;
            }
        }

        return default;
    }

    public virtual async Task<(bool Success, SuccessResult? Result, ErrorResult? Error)> SendAsync<SuccessResult, ErrorResult>(HttpMethod method, string uri, Dictionary<string, string>? headers, object? payload, CancellationToken? cancellationToken)
    {
        try
        {
            using var response = await ExecuteAsync(method, uri, true, headers, payload, cancellationToken);

            var responseStr = await response.Content.ReadAsStringAsync();
            return new(true, JsonConvert.DeserializeObject<SuccessResult>(responseStr), default);
        }
        catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.BadRequest)
        {
            var responseStr = ex.Message;
            return new(false, default, JsonConvert.DeserializeObject<ErrorResult>(responseStr));
        }
    }

    public virtual async Task<Result?> SendAsync<Result>(HttpMethod method, string uri, bool ensureSuccessStatusCode = true, Dictionary<string, string>? headers = null, CancellationToken? cancellationToken = null)
        => await SendAsync<Result>(method, uri, ensureSuccessStatusCode, headers, null, cancellationToken);

    public virtual async Task<(bool Success, SuccessResult? Result, ErrorResult? Error)> SendAsync<SuccessResult, ErrorResult>(HttpMethod method, string uri, Dictionary<string, string>? headers = null, CancellationToken? cancellationToken = null)
        => await SendAsync<SuccessResult, ErrorResult>(method, uri, headers, null, cancellationToken);

    public virtual async Task SendAsync(HttpMethod method, string uri, bool ensureSuccessStatusCode, Dictionary<string, string>? headers, object? payload, CancellationToken? cancellationToken = null)
        => await ExecuteAsync(method, uri, ensureSuccessStatusCode, headers, payload, cancellationToken);

    public virtual async Task SendAsync(HttpMethod method, string uri, bool ensureSuccessStatusCode = true, Dictionary<string, string>? headers = null, CancellationToken? cancellationToken = null)
        => await SendAsync(method, uri, ensureSuccessStatusCode, headers, null, cancellationToken);

    public virtual async Task<Result?> GetAsync<Result>(string uri, bool ensureSuccessStatusCode = true, Dictionary<string, string>? headers = null, CancellationToken? cancellationToken = null)
        => await SendAsync<Result>(HttpMethod.Get, uri, ensureSuccessStatusCode, headers, cancellationToken);

    public virtual async Task<Result?> PostAsync<Result>(string uri, object? payload = null, bool ensureSuccessStatusCode = true, Dictionary<string, string>? headers = null, CancellationToken? cancellationToken = null)
        => await SendAsync<Result>(HttpMethod.Post, uri, ensureSuccessStatusCode, headers, payload, cancellationToken);

    public virtual async Task<(bool Success, SuccessResult? Result, ErrorResult? Error)> GetAsync<SuccessResult, ErrorResult>(string uri, Dictionary<string, string>? headers = null, CancellationToken? cancellationToken = null)
        => await SendAsync<SuccessResult, ErrorResult>(HttpMethod.Get, uri, headers, cancellationToken);

    public virtual async Task<(bool Success, SuccessResult? Result, ErrorResult? Error)> PostAsync<SuccessResult, ErrorResult>(string uri, object? payload = null, Dictionary<string, string>? headers = null, CancellationToken? cancellationToken = null)
        => await SendAsync<SuccessResult, ErrorResult>(HttpMethod.Post, uri, headers, payload, cancellationToken);

    public virtual async Task PostAsync(string uri, object? payload = null, bool ensureSuccessStatusCode = true, Dictionary<string, string>? headers = null, CancellationToken? cancellationToken = null)
        => await SendAsync(HttpMethod.Post, uri, ensureSuccessStatusCode, headers, payload, cancellationToken);
}