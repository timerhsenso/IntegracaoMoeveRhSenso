using IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;
using IntegracaoCepsaBrasil.Proxy.Common;
using Microsoft.Extensions.Logging;

namespace IntegracaoCepsaBrasil.Proxy.CEPSA;

/// <summary>
/// Repositório REST para consumo da API CEPSA (SAP SuccessFactors).
/// As rotas dos endpoints são configuráveis via seção "EndpointRoutes" do appsettings.json,
/// permitindo alteração sem necessidade de recompilação.
/// </summary>
public class CEPSARESTRepository(
    IHttpClientFactory httpClientFactory,
    ILogger<CEPSARESTRepository> logger,
    EndpointRoutesConfiguration routes) : BaseRESTRepository(httpClientFactory, logger), ICEPSARESTRepository
{
    private readonly EndpointRoutesConfiguration _routes = routes;

    public async Task<Resultadocust_DatosSindicalesBRA?> GetDatosSindicales(DateTime date, CancellationToken cancellationToken)
    {
        var url = EndpointRoutesConfiguration.Resolve(_routes.DatosSindicales, date);
        return await GetAsync<Resultadocust_DatosSindicalesBRA>(url, cancellationToken: cancellationToken);
    }

    public async Task<Resultadocust_FiscalData_PT?> GetFiscalData(DateTime date, CancellationToken cancellationToken)
    {
        var url = EndpointRoutesConfiguration.Resolve(_routes.FiscalData, date);
        return await GetAsync<Resultadocust_FiscalData_PT>(url, cancellationToken: cancellationToken);
    }

    public async Task<ResultadoEmpJobDEFLT?> GetEmpJob(DateTime date, CancellationToken cancellationToken)
    {
        var url = EndpointRoutesConfiguration.Resolve(_routes.EmpJob, date);
        return await GetAsync<ResultadoEmpJobDEFLT>(url, cancellationToken: cancellationToken);
    }

    public async Task<ResultadoPerAddressDEFLT?> GetPerAddressDEFLT(DateTime date, CancellationToken cancellationToken)
    {
        var url = EndpointRoutesConfiguration.Resolve(_routes.PerAddressDEFLT, date);
        return await GetAsync<ResultadoPerAddressDEFLT>(url, cancellationToken: cancellationToken);
    }

    public async Task<ResultadoPerEmail?> GetPerEmail(DateTime date, CancellationToken cancellationToken)
    {
        var url = EndpointRoutesConfiguration.Resolve(_routes.PerEmail, date);
        return await GetAsync<ResultadoPerEmail>(url, cancellationToken: cancellationToken);
    }

    public async Task<ResultadoPerPerson?> GetPerPerson(DateTime date, CancellationToken cancellationToken)
    {
        var url = EndpointRoutesConfiguration.Resolve(_routes.PerPerson, date);
        return await GetAsync<ResultadoPerPerson>(url, cancellationToken: cancellationToken);
    }

    public async Task<ResultadoPerPersonal?> GetPerPersonal(DateTime date, CancellationToken cancellationToken)
    {
        var url = EndpointRoutesConfiguration.Resolve(_routes.PerPersonal, date);
        return await GetAsync<ResultadoPerPersonal>(url, cancellationToken: cancellationToken);
    }

    public async Task<ResultadoCustDatosSindicalesBRA?> GetPerPhone(DateTime date, CancellationToken cancellationToken)
    {
        var url = EndpointRoutesConfiguration.Resolve(_routes.PerPhone, date);
        return await GetAsync<ResultadoCustDatosSindicalesBRA>(url, cancellationToken: cancellationToken);
    }
}