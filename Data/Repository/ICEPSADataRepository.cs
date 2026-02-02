using IntegracaoCepsaBrasil.Data.Models;

namespace IntegracaoCepsaBrasil.Data.Repository;

public interface ICEPSADataRepository
{
    Task<int> ImportDatosSindicales(IEnumerable<DatosSindicales> datosSindicales, DateTime date, CancellationToken cancellationToken);
    Task<int> ImportEmpJob(IEnumerable<EmpJob> empJob, DateTime date, CancellationToken cancellationToken);
    Task<int> ImportPerAddress(IEnumerable<PerAddress> perAddress, DateTime date, CancellationToken cancellationToken);
    Task<int> ImportPerEmail(IEnumerable<PerEmail> perEmail, DateTime date, CancellationToken cancellationToken);
    Task<int> ImportPerPerson(IEnumerable<PerPerson> perPerson, DateTime date, CancellationToken cancellationToken);
    Task<int> ImportPerPersonal(IEnumerable<PerPersonal> perPersonal, DateTime date, CancellationToken cancellationToken);
    Task<int> ImportPerPhone(IEnumerable<PerPhone> perPhone, DateTime date, CancellationToken cancellationToken);
}