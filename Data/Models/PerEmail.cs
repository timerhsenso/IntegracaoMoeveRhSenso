using IntegracaoCepsaBrasil.Data.Common;
using IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoCepsaBrasil.Data.Models;

[Table("sapsf_PerEmail")]
public record PerEmail : BaseModel
{
    [Column("emailAddress", TypeName = "varchar(5000)")]
    public string? EmailAddress { get; set; }

    [Column("emailType", TypeName = "varchar(5000)")]
    public string? EmailType { get; set; }

    [Column("personIdExternal", TypeName = "varchar(5000)")]
    public string? PersonIdExternal { get; set; }

    [Column("company", TypeName = "varchar(5000)")]
    public string? Company { get; set; }

    [Column("userId", TypeName = "varchar(5000)")]
    public string? UserId { get; set; }

    public static explicit operator PerEmail(PerEmailArray perEmail) =>
        new()
        {
            EmailAddress = perEmail.EmailAddress,
            EmailType = perEmail.EmailType,
            PersonIdExternal = perEmail.PersonIdExternal,
            Company = perEmail.Company,
            UserId = perEmail.UserId
        };
}
