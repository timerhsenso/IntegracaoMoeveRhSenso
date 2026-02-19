using System.ComponentModel.DataAnnotations.Schema;

namespace IntegracaoCepsaBrasil.Data.Models;

[Table("IntegrationExecutionLog")]
public record ExecutionLog
{
    [Column("id")]
    public long Id { get; set; }

    [Column("executionDateTime")]
    public DateTime ExecutionDateTime { get; set; }

    [Column("tableName", TypeName = "varchar(100)")]
    public string TableName { get; set; } = string.Empty;

    [Column("requestedDate")]
    public DateTime RequestedDate { get; set; }

    [Column("recordsImported")]
    public int RecordsImported { get; set; }

    [Column("durationMs")]
    public long DurationMs { get; set; }

    [Column("status", TypeName = "varchar(50)")]
    public string Status { get; set; } = string.Empty;

    [Column("errorMessage", TypeName = "varchar(max)")]
    public string? ErrorMessage { get; set; }
}