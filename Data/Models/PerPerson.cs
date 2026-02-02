using IntegracaoCepsaBrasil.Data.Common;
using IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoCepsaBrasil.Data.Models;

[Table("sapsf_PerPerson")]
public record PerPerson : BaseModel
{
    [Column("personIdExternal", TypeName = "varchar(5000)")]
    public string? PersonIdExternal { get; set; }

    [Column("customString4", TypeName = "varchar(5000)")]
    public string? CustomString4 { get; set; }

    [Column("dateOfBirth", TypeName = "varchar(5000)")]
    public string? DateOfBirth { get; set; }

    [Column("endDate", TypeName = "varchar(5000)")]
    public string? EndDate { get; set; }

    [Column("company", TypeName = "varchar(5000)")]
    public string? Company { get; set; }

    [Column("startDate", TypeName = "varchar(5000)")]
    public string? StartDate { get; set; }

    [Column("lastModifiedOn", TypeName = "varchar(5000)")]
    public string? LastModifiedOn { get; set; }

    public static explicit operator PerPerson(PerPersonArray perPerson) =>
        new()
        {
            PersonIdExternal = perPerson.PersonIdExternal,
            CustomString4 = perPerson.CustomString4,
            DateOfBirth = perPerson.DateOfBirth,
            EndDate = perPerson.EndDate,
            Company = perPerson.Company,
            StartDate = perPerson.StartDate,
            LastModifiedOn = perPerson.LastModifiedOn
        };
}
