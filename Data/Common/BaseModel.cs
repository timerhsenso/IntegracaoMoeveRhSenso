using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoCepsaBrasil.Data.Common;

public record BaseModel
{
    [Column("id")]
    public decimal Id { get; set; }

    [Column("date")]
    public DateTime Date { get; set; }
}
