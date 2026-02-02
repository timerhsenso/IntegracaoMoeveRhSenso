using IntegracaoCepsaBrasil.Data.Common;
using IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoCepsaBrasil.Data.Models;

[Table("sapsf_PerAddress")]
public record PerAddress : BaseModel
{
    [Column("zipCode", TypeName = "varchar(5000)")]
    public string? ZipCode { get; set; }

    [Column("address3", TypeName = "varchar(5000)")]
    public string? Address3 { get; set; }

    [Column("personIdExternal", TypeName = "varchar(5000)")]
    public string? PersonIdExternal { get; set; }

    [Column("company", TypeName = "varchar(5000)")]
    public string? Company { get; set; }

    [Column("userId", TypeName = "varchar(5000)")]
    public string? UserId { get; set; }

    [Column("address2", TypeName = "varchar(5000)")]
    public string? Address2 { get; set; }

    [Column("address1", TypeName = "varchar(5000)")]
    public string? Address1 { get; set; }

    [Column("address4", TypeName = "varchar(5000)")]
    public string? Address4 { get; set; }

    [Column("customString2", TypeName = "varchar(5000)")]
    public string? CustomString2 { get; set; }

    public static explicit operator PerAddress(PerAddressDEFLTArray perAddress) =>
        new()
        {
            ZipCode = perAddress.ZipCode,
            Address3 = perAddress.Address3,
            PersonIdExternal = perAddress.PersonIdExternal,
            Company = perAddress.Company,
            UserId = perAddress.UserId,
            Address2 = perAddress.Address2,
            Address1 = perAddress.Address1,
            Address4 = perAddress.Address4,
            CustomString2 = perAddress.CustomString2
        };
}
