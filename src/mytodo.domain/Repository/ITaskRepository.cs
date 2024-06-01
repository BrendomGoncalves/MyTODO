using mytodo.domain.Entities;

namespace mytodo.domain.Repository;

public interface ITaskRepository
{
    Task<TaskEntity> CreateTaskAsync(TaskEntity task);
    Task<TaskEntity?> GetTaskByIdAsync(int id);
    Task<List<TaskEntity>> GetTasksAsync();
    Task<TaskEntity> DeleteTaskAsync(TaskEntity task);
    Task<TaskEntity> UpdateTaskAsync(TaskEntity task);
}