using IntegracaoCepsaBrasil.Data.Common;
using IntegracaoCepsaBrasil.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegracaoCepsaBrasil.Data.Repository;

public class CEPSADataRepository(DbContextOptions<CEPSADbContext> _dbContextOptions) : BaseDataRepository, ICEPSADataRepository
{
    public async Task<int> ImportDatosSindicales(IEnumerable<DatosSindicales> datosSindicales, DateTime date, CancellationToken cancellationToken)
    {
        using var dbContext = new CEPSADbContext(_dbContextOptions);
        using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await dbContext.DatosSindicales.Where(x => x.Date == date).ExecuteDeleteAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            // ✅ CRIAR NOVOS OBJETOS (não usar 'with' que mantém rastreamento)
            var entities = datosSindicales.Select(r => new DatosSindicales
            {
                Id = 0,
                Date = date,
                CustCodigoDoSindicato = r.CustCodigoDoSindicato,
                CustIndicadorDeSindicalizado = r.CustIndicadorDeSindicalizado,
                LastModifiedDateTime = r.LastModifiedDateTime,
                ExternalCode = r.ExternalCode
            }).ToList();

            await dbContext.DatosSindicales.AddRangeAsync(entities, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return entities.Count;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task<int> ImportEmpJob(IEnumerable<EmpJob> empJob, DateTime date, CancellationToken cancellationToken)
    {
        using var dbContext = new CEPSADbContext(_dbContextOptions);
        using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await dbContext.EmpJob.Where(x => x.Date == date).ExecuteDeleteAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            var entities = empJob.Select(r => new EmpJob
            {
                Id = 0,
                Date = date,
                CustomString160 = r.CustomString160,
                CustomString151 = r.CustomString151,
                CustomString150 = r.CustomString150,
                CustomString153 = r.CustomString153,
                CustomString152 = r.CustomString152,
                CustomString155 = r.CustomString155,
                ContractType = r.ContractType,
                CostCenter = r.CostCenter,
                CustomString154 = r.CustomString154,
                UserId = r.UserId,
                LastModifiedOn = r.LastModifiedOn,
                WorkerCategory = r.WorkerCategory,
                CustomString157 = r.CustomString157,
                CustomString156 = r.CustomString156,
                CustomString159 = r.CustomString159,
                Company = r.Company
            }).ToList();

            await dbContext.EmpJob.AddRangeAsync(entities, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return entities.Count;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task<int> ImportPerAddress(IEnumerable<PerAddress> perAddress, DateTime date, CancellationToken cancellationToken)
    {
        using var dbContext = new CEPSADbContext(_dbContextOptions);
        using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await dbContext.PerAddressDEFLT.Where(x => x.Date == date).ExecuteDeleteAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            var entities = perAddress.Select(r => new PerAddress
            {
                Id = 0,
                Date = date,
                ZipCode = r.ZipCode,
                Address3 = r.Address3,
                PersonIdExternal = r.PersonIdExternal,
                Company = r.Company,
                UserId = r.UserId,
                Address2 = r.Address2,
                Address1 = r.Address1,
                Address4 = r.Address4,
                CustomString2 = r.CustomString2
            }).ToList();

            await dbContext.PerAddressDEFLT.AddRangeAsync(entities, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return entities.Count;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task<int> ImportPerEmail(IEnumerable<PerEmail> perEmail, DateTime date, CancellationToken cancellationToken)
    {
        using var dbContext = new CEPSADbContext(_dbContextOptions);
        using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await dbContext.PerEmail.Where(x => x.Date == date).ExecuteDeleteAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            var entities = perEmail.Select(r => new PerEmail
            {
                Id = 0,
                Date = date,
                EmailAddress = r.EmailAddress,
                EmailType = r.EmailType,
                PersonIdExternal = r.PersonIdExternal,
                Company = r.Company,
                UserId = r.UserId
            }).ToList();

            await dbContext.PerEmail.AddRangeAsync(entities, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return entities.Count;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task<int> ImportPerPerson(IEnumerable<PerPerson> perPerson, DateTime date, CancellationToken cancellationToken)
    {
        using var dbContext = new CEPSADbContext(_dbContextOptions);
        using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await dbContext.PerPerson.Where(x => x.Date == date).ExecuteDeleteAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            var entities = perPerson.Select(r => new PerPerson
            {
                Id = 0,
                Date = date,
                PersonIdExternal = r.PersonIdExternal,
                CustomString4 = r.CustomString4,
                DateOfBirth = r.DateOfBirth,
                EndDate = r.EndDate,
                Company = r.Company,
                StartDate = r.StartDate,
                LastModifiedOn = r.LastModifiedOn
            }).ToList();

            await dbContext.PerPerson.AddRangeAsync(entities, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return entities.Count;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task<int> ImportPerPersonal(IEnumerable<PerPersonal> perPersonal, DateTime date, CancellationToken cancellationToken)
    {
        using var dbContext = new CEPSADbContext(_dbContextOptions);
        using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await dbContext.PerPersonal.Where(x => x.Date == date).ExecuteDeleteAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            var entities = perPersonal.Select(r => new PerPersonal
            {
                Id = 0,
                Date = date,
                Gender = r.Gender,
                Nationality = r.Nationality,
                PersonIdExternal = r.PersonIdExternal,
                CustomString2 = r.CustomString2,
                CustomString7 = r.CustomString7,
                StartDate = r.StartDate,
                LastModifiedOn = r.LastModifiedOn,
                MaritalStatus = r.MaritalStatus,
                UserId = r.UserId,
                Company = r.Company
            }).ToList();

            await dbContext.PerPersonal.AddRangeAsync(entities, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return entities.Count;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }

    public async Task<int> ImportPerPhone(IEnumerable<PerPhone> perPhone, DateTime date, CancellationToken cancellationToken)
    {
        using var dbContext = new CEPSADbContext(_dbContextOptions);
        using var transaction = await dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            await dbContext.PerPhone.Where(x => x.Date == date).ExecuteDeleteAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            var entities = perPhone.Select(r => new PerPhone
            {
                Id = 0,
                Date = date,
                PersonIdExernal = r.PersonIdExernal,
                BusinessPhone = r.BusinessPhone,
                PersonalPhone = r.PersonalPhone,
                Extension = r.Extension,
                AreaCode = r.AreaCode
            }).ToList();

            await dbContext.PerPhone.AddRangeAsync(entities, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();

            await dbContext.SaveChangesAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);

            return entities.Count;
        }
        catch
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }
    }
}