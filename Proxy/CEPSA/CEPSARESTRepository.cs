using IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;
using IntegracaoCepsaBrasil.Proxy.Common;
using Microsoft.Extensions.Logging; // ← ADICIONAR


namespace IntegracaoCepsaBrasil.Proxy.CEPSA;

public class CEPSARESTRepository(
    IHttpClientFactory httpClientFactory,
    ILogger<CEPSARESTRepository> logger) : BaseRESTRepository(httpClientFactory, logger), ICEPSARESTRepository
{
    public async Task<Resultadocust_DatosSindicalesBRA?> GetDatosSindicales(DateTime date, CancellationToken cancellationToken)
    {
        return await GetAsync<Resultadocust_DatosSindicalesBRA>($"v1/DatosSindicales?date={date:yyyy-MM-dd}", cancellationToken: cancellationToken);        
    }

    public async Task<Resultadocust_FiscalData_PT?> GetFiscalData(DateTime date, CancellationToken cancellationToken)
    {
        return await GetAsync<Resultadocust_FiscalData_PT>($"v1/FiscalData?date={date:yyyy-MM-dd}", cancellationToken: cancellationToken);
    }

    public async Task<ResultadoEmpJobDEFLT?> GetEmpJob(DateTime date, CancellationToken cancellationToken)
    {
        return await GetAsync<ResultadoEmpJobDEFLT>($"v1/EmpJob?date={date:yyyy-MM-dd}", cancellationToken: cancellationToken);
    }

    public async Task<ResultadoPerAddressDEFLT?> GetPerAddressDEFLT(DateTime date, CancellationToken cancellationToken)
    {
        return await GetAsync<ResultadoPerAddressDEFLT>($"v1/PerAddressDEFLT?date={date:yyyy-MM-dd}", cancellationToken: cancellationToken);
    }

    public async Task<ResultadoPerEmail?> GetPerEmail(DateTime date, CancellationToken cancellationToken)
    {
        return await GetAsync<ResultadoPerEmail>($"v1/PerEmail?date={date:yyyy-MM-dd}", cancellationToken: cancellationToken);
    }

    public async Task<ResultadoPerPerson?> GetPerPerson(DateTime date, CancellationToken cancellationToken)
    {
        return await GetAsync<ResultadoPerPerson>($"v1/PerPerson?date={date:yyyy-MM-dd}", cancellationToken: cancellationToken);
    }

    public async Task<ResultadoPerPersonal?> GetPerPersonal(DateTime date, CancellationToken cancellationToken)
    {
        return await GetAsync<ResultadoPerPersonal>($"v1/PerPersonal?date={date:yyyy-MM-dd}", cancellationToken: cancellationToken);
    }

    public async Task<ResultadoCustDatosSindicalesBRA?> GetPerPhone(DateTime date, CancellationToken cancellationToken)
    {
        return await GetAsync<ResultadoCustDatosSindicalesBRA>($"v1/PerPhone?date={date:yyyy-MM-dd}");
    }
}
