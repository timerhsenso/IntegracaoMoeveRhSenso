using IntegracaoCepsaBrasil.Data.Common;
using IntegracaoCepsaBrasil.Proxy.CEPSA.Responses;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoCepsaBrasil.Data.Models;

[Table("sapsf_FiscalData")]
public record FiscalData : BaseModel
{
    [Column("cust_NTituloDeEleitor", TypeName = "varchar(5000)")]
    public string? CustNTituloDeEleitor { get; set; }

    [Column("cust_DTEmissaoDoTitulo", TypeName = "varchar(5000)")]
    public string? CustDTEmissaoDoTitulo { get; set; }

    [Column("cust_SecaoDoTituloDeEleitor", TypeName = "varchar(5000)")]
    public string? CustSecaoDoTituloDeEleitor { get; set; }

    [Column("cust_ZonaDoTituloDeEleitor", TypeName = "varchar(5000)")]
    public string? CustZonaDoTituloDeEleitor { get; set; }

    [Column("cust_UFDoTituloDeEleitor", TypeName = "varchar(5000)")]
    public string? CustUFDoTituloDeEleitor { get; set; }

    [Column("lastModifiedDateTime", TypeName = "varchar(5000)")]
    public string? LastModifiedDateTime { get; set; }

    [Column("externalCode", TypeName = "varchar(5000)")]
    public string? ExternalCode { get; set; }

    public static explicit operator FiscalData(CustFiscalDataPTArray fiscalData) =>
        new()
        {
            CustNTituloDeEleitor = fiscalData.CustNTituloDeEleitor,
            CustDTEmissaoDoTitulo = fiscalData.CustDTEmissaoDoTitulo,
            CustSecaoDoTituloDeEleitor = fiscalData.CustSecaoDoTituloDeEleitor,
            CustZonaDoTituloDeEleitor = fiscalData.CustZonaDoTituloDeEleitor,
            CustUFDoTituloDeEleitor = fiscalData.CustUFDoTituloDeEleitor,
            LastModifiedDateTime = fiscalData.LastModifiedDateTime,
            ExternalCode = fiscalData.ExternalCode
        };
}
