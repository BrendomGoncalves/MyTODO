namespace mytodo.domain.Entities;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; } = "Pending"; // Default status is Pending
    public string Priority { get; set; } = "Medium"; // Default priority is Medium
    public int UserId { get; set; }
    public User User { get; set; }
}
