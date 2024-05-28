using mytodo.domain.Repository;

namespace mytodo.data.Repositories;
public class Repository<T> :
    IDisposable, IRepository<T> where T : class
{
    private readonly MytodoDbContext _context;
    private bool dispose;
    
    public Repository(MytodoDbContext context)
    {
        _context = context;
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        return entity;
    }

    public T Update(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }

    private void Dispose(bool disposing)
    {
        if (!dispose && disposing)
        {
            _context.Dispose();
        }

        dispose = true;
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}