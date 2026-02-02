using IntegracaoCepsaBrasil.Data.Common;
using IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoCepsaBrasil.Data.Models;

[Table("sapsf_PerPhone")]
public record PerPhone : BaseModel
{
    [Column("personIdExernal", TypeName = "varchar(5000)")]
    public string? PersonIdExernal { get; set; }

    [Column("businessPhone", TypeName = "varchar(5000)")]
    public string? BusinessPhone { get; set; }

    [Column("personalPhone", TypeName = "varchar(5000)")]
    public string? PersonalPhone { get; set; }

    [Column("Extension", TypeName = "varchar(5000)")]
    public string? Extension { get; set; }

    [Column("AreaCode", TypeName = "varchar(5000)")]
    public string? AreaCode { get; set; }

    public static explicit operator PerPhone(PerPhoneArray v)
    {
        return new()
        {
            PersonIdExernal = v.PersonIdExernal,
            BusinessPhone = v.BusinessPhone,
            PersonalPhone = v.PersonalPhone,
            Extension = v.Extension,
            AreaCode = v.AreaCode
        };
    }
}
