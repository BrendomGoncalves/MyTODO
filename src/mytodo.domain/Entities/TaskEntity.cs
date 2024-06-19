using System.Diagnostics.CodeAnalysis;

namespace mytodo.domain.Entities;

[ExcludeFromCodeCoverage]
public class TaskEntity : BaseEntity
{
    public int TaskId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateOnly DataVencimento { get; set; }
    public string Status { get; set; } = "Pending";
    public string Priority { get; set; } = "Medium";
    public required int UserId { get; set; }
    public UserEntity User { get; set; } = default!;
}
