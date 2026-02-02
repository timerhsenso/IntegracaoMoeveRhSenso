using IntegracaoCepsaBrasil.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegracaoCepsaBrasil.Data;

public class CEPSADbContext : DbContext
{
    public CEPSADbContext(DbContextOptions<CEPSADbContext> options) : base(options)
    {
    }

    public DbSet<DatosSindicales> DatosSindicales { get; set; }
    public DbSet<EmpJob> EmpJob { get; set; }
    public DbSet<PerAddress> PerAddressDEFLT { get; set; }
    public DbSet<PerEmail> PerEmail { get; set; }
    public DbSet<PerPerson> PerPerson { get; set; }
    public DbSet<PerPersonal> PerPersonal { get; set; }
    public DbSet<PerPhone> PerPhone { get; set; }
    public DbSet<ExecutionLog> ExecutionLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ✅ ExecutionLog indexes para performance
        modelBuilder.Entity<ExecutionLog>(entity =>
        {
            entity.HasIndex(e => e.ExecutionDateTime).HasDatabaseName("IX_ExecutionDateTime");
            entity.HasIndex(e => e.TableName).HasDatabaseName("IX_TableName");
            entity.HasIndex(e => e.Status).HasDatabaseName("IX_Status");
        });
    }
}