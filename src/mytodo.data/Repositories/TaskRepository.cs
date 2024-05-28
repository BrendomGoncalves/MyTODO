using Microsoft.EntityFrameworkCore;
using mytodo.domain.Entities;
using mytodo.domain.Repository;

namespace mytodo.data.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly MytodoDbContext _context;

    public TaskRepository(MytodoDbContext context)
    {
        _context = context;
    }
    
    public Task<TaskEntity> CreateTaskAsync(TaskEntity task)
    {
        _context.Tasks.Add(task);
        return Task.FromResult(task);
    }

    public async Task<TaskEntity> GetTaskByIdAsync(int id)
    {
        var task = await _context.Tasks.FirstOrDefaultAsync(task => task.TaskId == id);
        if (task == null)
        {
            // TODO: Criar exceção personalizada
            throw new Exception("Task not found");
        }
        return task;
    }

    public async Task<List<TaskEntity>> GetTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public Task<TaskEntity> DeleteTaskAsync(TaskEntity task)
    {
        _context.Tasks.Remove(task);
        return Task.FromResult(task);
    }
}