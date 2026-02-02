using IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;

namespace IntegracaoCepsaBrasil.Proxy.CEPSA;

public interface ICEPSARESTRepository
{
    Task<Resultadocust_DatosSindicalesBRA?> GetDatosSindicales(DateTime date, CancellationToken cancellationToken);
    Task<Resultadocust_FiscalData_PT?> GetFiscalData(DateTime date, CancellationToken cancellationToken);
    Task<ResultadoEmpJobDEFLT?> GetEmpJob(DateTime date, CancellationToken cancellationToken);
    Task<ResultadoPerAddressDEFLT?> GetPerAddressDEFLT(DateTime date, CancellationToken cancellationToken);
    Task<ResultadoPerEmail?> GetPerEmail(DateTime date, CancellationToken cancellationToken);
    Task<ResultadoPerPerson?> GetPerPerson(DateTime date, CancellationToken cancellationToken);
    Task<ResultadoPerPersonal?> GetPerPersonal(DateTime date, CancellationToken cancellationToken);
    Task<ResultadoCustDatosSindicalesBRA?> GetPerPhone(DateTime date, CancellationToken cancellationToken);
}