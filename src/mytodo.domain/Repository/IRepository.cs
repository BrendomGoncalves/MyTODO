namespace mytodo.domain.Repository;

public interface IRepository<T> where T : class
{
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    T Update(T entity);
}