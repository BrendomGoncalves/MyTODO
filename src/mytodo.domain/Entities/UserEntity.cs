using System.Diagnostics.CodeAnalysis;

namespace mytodo.domain.Entities;

[ExcludeFromCodeCoverage]
public class UserEntity : BaseEntity
{
    public int UserId { get; set; }

    public required string Username { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }

    public IEnumerable<TaskEntity>? Tasks { get; set; }
}