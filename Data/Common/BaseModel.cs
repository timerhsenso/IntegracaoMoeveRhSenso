using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoCepsaBrasil.Data.Common;

public record BaseModel
{
    [Column("id")]
    public int Id { get; set; }

    [Column("date")]
    public DateTime Date { get; set; }
}
