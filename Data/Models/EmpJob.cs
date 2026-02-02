using IntegracaoCepsaBrasil.Data.Common;
using IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoCepsaBrasil.Data.Models;

[Table("sapsf_EmpJob")]
public record EmpJob : BaseModel
{
    [Column("customString160", TypeName = "varchar(5000)")]
    public string? CustomString160 { get; set; }

    [Column("customString151", TypeName = "varchar(5000)")]
    public string? CustomString151 { get; set; }

    [Column("customString150", TypeName = "varchar(5000)")]
    public string? CustomString150 { get; set; }

    [Column("customString153", TypeName = "varchar(5000)")]
    public string? CustomString153 { get; set; }

    [Column("customString152", TypeName = "varchar(5000)")]
    public string? CustomString152 { get; set; }

    [Column("customString155", TypeName = "varchar(5000)")]
    public string? CustomString155 { get; set; }

    [Column("contractType", TypeName = "varchar(5000)")]
    public string? ContractType { get; set; }

    [Column("costCenter", TypeName = "varchar(5000)")]
    public string? CostCenter { get; set; }

    [Column("customString154", TypeName = "varchar(5000)")]
    public string? CustomString154 { get; set; }

    [Column("userId", TypeName = "varchar(5000)")]
    public string? UserId { get; set; }

    [Column("lastModifiedOn", TypeName = "varchar(5000)")]
    public string? LastModifiedOn { get; set; }

    [Column("workerCategory", TypeName = "varchar(5000)")]
    public string? WorkerCategory { get; set; }

    [Column("customString157", TypeName = "varchar(5000)")]
    public string? CustomString157 { get; set; }

    [Column("customString156", TypeName = "varchar(5000)")]
    public string? CustomString156 { get; set; }

    [Column("customString159", TypeName = "varchar(5000)")]
    public string? CustomString159 { get; set; }

    [Column("company", TypeName = "varchar(5000)")]
    public string? Company { get; set; }

    public static explicit operator EmpJob(EmpJobArray empJob) =>
        new()
        {
            CustomString160 = empJob.CustomString160,
            CustomString151 = empJob.CustomString151,
            CustomString150 = empJob.CustomString150,
            CustomString153 = empJob.CustomString153,
            CustomString152 = empJob.CustomString152,
            CustomString155 = empJob.CustomString155,
            ContractType = empJob.ContractType,
            CostCenter = empJob.CostCenter,
            CustomString154 = empJob.CustomString154,
            UserId = empJob.UserId,
            LastModifiedOn = empJob.LastModifiedOn,
            WorkerCategory = empJob.WorkerCategory,
            CustomString157 = empJob.CustomString157,
            CustomString156 = empJob.CustomString156,
            CustomString159 = empJob.CustomString159,
            Company = empJob.Company
        };
}
