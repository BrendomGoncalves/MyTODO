namespace mytodo.shareable.Dtos;

public class TaskDto
 {
     public int TaskId { get; set; }
     public string Title { get; set; }
     public string? Description { get; set; }
     public DateTime DueDate { get; set; }
     public string Status { get; set; }
     public string Priority { get; set; }
     public int UserId { get; set; }
     
        public TaskDto(int taskId, string title, string? description, DateTime dueDate, int userId, 
            string status = "Pending", string priority = "Medium")
        {
            TaskId = taskId;
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
            Priority = priority;
            UserId = userId;
        }
 }