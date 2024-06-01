using mytodo.domain.Repository;

namespace mytodo.data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly MytodoDbContext _context;
    private readonly Dictionary<Type, object> _repositories;
    
    public UnitOfWork(MytodoDbContext context)
    {
        _context = context;
        _repositories = new Dictionary<Type, object>();
    }
    
    public IRepository<T> Repository<T>()
        where T : class
    {
        if (_repositories.TryGetValue(typeof(T), out var value))
        {
            return (IRepository<T>)value;
        }

        var repository = new Repository<T>(_context);
        _repositories[typeof(T)] = repository;

        return repository;
    }
    
    public async Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var retorno = await _context.SaveChangesAsync(cancellationToken);

        return retorno > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}