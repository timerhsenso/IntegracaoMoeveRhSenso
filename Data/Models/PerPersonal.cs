using IntegracaoCepsaBrasil.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoCepsaBrasil.Data.Models;

[Table("sapsf_PerPersonal")]
public record PerPersonal : BaseModel
{
    [Column("gender", TypeName = "varchar(5000)")]
    public string? Gender { get; set; }

    [Column("nationality", TypeName = "varchar(5000)")]
    public string? Nationality { get; set; }

    [Column("personIdExternal", TypeName = "varchar(5000)")]
    public string? PersonIdExternal { get; set; }

    [Column("customString2", TypeName = "varchar(5000)")]
    public string? CustomString2 { get; set; }

    [Column("customString7", TypeName = "varchar(5000)")]
    public string? CustomString7 { get; set; }

    [Column("startDate")]
    public DateTime? StartDate { get; set; }

    [Column("lastModifiedOn")]
    public DateTime? LastModifiedOn { get; set; }

    [Column("maritalStatus", TypeName = "varchar(5000)")]
    public string? MaritalStatus { get; set; }

    [Column("userId", TypeName = "varchar(5000)")]
    public string? UserId { get; set; }

    [Column("company", TypeName = "varchar(5000)")]
    public string? Company { get; set; }

    public static explicit operator PerPersonal(Proxy.CEPSA.Responses.PerPersonal perPersonal) =>
        new()
        {
            Gender = perPersonal.Gender,
            Nationality = perPersonal.Nationality,
            PersonIdExternal = perPersonal.PersonIdExternal,
            CustomString2 = perPersonal.CustomString2,
            CustomString7 = perPersonal.CustomString7,
            StartDate = perPersonal.StartDate,
            LastModifiedOn = perPersonal.LastModifiedOn,
            MaritalStatus = perPersonal.MaritalStatus,
            UserId = perPersonal.UserId,
            Company = perPersonal.Company
        };
}
