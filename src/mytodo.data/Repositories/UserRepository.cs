using Microsoft.EntityFrameworkCore;
using mytodo.domain.Entities;
using mytodo.domain.Repository;

namespace mytodo.data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly MytodoDbContext _context;

    public UserRepository(MytodoDbContext context)
    {
        _context = context;
    }
    
    public Task<UserEntity> CreateUserAsync(UserEntity user)
    {
        _context.Users.Add(user);
        return Task.FromResult(user);
    }

    public async Task<UserEntity?> GetUserByEmailAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            // TODO: Criar exceção personalizada
            throw new Exception("User not found");
        }
        return user;
    }

    public async Task<UserEntity> GetUserByIdAsync(int id)
    {
        var user = await _context.Users.FirstOrDefaultAsync(user => user.UserId == id);
        if (user == null)
        {
            // TODO: Criar exceção personalizada
            throw new Exception("User not found");
        }
        return user;
    }

    public async Task<List<UserEntity>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync(); 
    }

    public Task<UserEntity> UpdateUserAsync(UserEntity user)
    {
        _context.Users.Update(user);
        return Task.FromResult(user);
    }

    public Task<UserEntity> DeleteUserAsync(UserEntity user)
    {
        _context.Users.Remove(user);
        return Task.FromResult(user);
    }
}