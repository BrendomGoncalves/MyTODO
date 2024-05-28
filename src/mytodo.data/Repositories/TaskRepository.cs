using mytodo.domain.Repository;

namespace mytodo.data.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly MytodoDbContext _context;

    public TaskRepository(MytodoDbContext context)
    {
        _context = context;
    }
    
    // TODO: Implementar métodos de ITaskRepository
}