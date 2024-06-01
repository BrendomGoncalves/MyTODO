using mytodo.domain.Entities;

namespace mytodo.domain.Repository;

public interface IUserRepository
{
    Task<UserEntity> CreateUserAsync(UserEntity user);
    Task<UserEntity?> GetUserByIdAsync(int id);
    Task<List<UserEntity>> GetUsersAsync();
    Task<UserEntity> UpdateUserAsync(UserEntity user);
    Task<UserEntity> DeleteUserAsync(UserEntity user);
}