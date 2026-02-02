using IntegracaoCepsaBrasil.Data.Common;
using IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoCepsaBrasil.Data.Models;

[Table("sapsf_DatosSindicales")]
public record DatosSindicales : BaseModel
{
    [Column("cust_CodigoDoSindicato", TypeName = "varchar(5000)")]
    public string? CustCodigoDoSindicato { get; set; }

    [Column("cust_IndicadorDeSindicalizado", TypeName = "varchar(5000)")]
    public string? CustIndicadorDeSindicalizado { get; set; }

    [Column("lastModifiedDateTime")]
    public DateTime? LastModifiedDateTime { get; set; }

    [Column("externalCode", TypeName = "varchar(5000)")]
    public string? ExternalCode { get; set; }

    public static explicit operator DatosSindicales(CustDatosSindicalesBRAArray datosSindicales) =>
        new()
        {
            CustCodigoDoSindicato = datosSindicales.CustCodigoDoSindicato,
            CustIndicadorDeSindicalizado = datosSindicales.CustIndicadorDeSindicalizado,
            LastModifiedDateTime = datosSindicales.LastModifiedDateTime,
            ExternalCode = datosSindicales.ExternalCode
        };
}
