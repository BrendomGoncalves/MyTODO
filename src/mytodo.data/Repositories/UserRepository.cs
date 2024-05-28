using mytodo.domain.Repository;

namespace mytodo.data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MytodoDbContext _context;

    public UserRepository(MytodoDbContext context)
    {
        _context = context;
    }
    
    // TODO: Implementar métodos de IUserRepository
}