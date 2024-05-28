namespace mytodo.domain.Entities;

public class TaskEntity
{
    public int TaskId { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; } = "Pending";
    public string Priority { get; set; } = "Medium";
    public required int UserId { get; set; }
    public UserEntity User { get; set; } = default!;
}
