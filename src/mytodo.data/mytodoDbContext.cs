using Microsoft.EntityFrameworkCore;
using mytodo.domain.Entities;

namespace mytodo.data;

public class MytodoDbContext : DbContext
{
    public DbSet<UserEntity> User { get; set; } = default!;
    public DbSet<TaskEntity> Task { get; set; } = default!;
    
    public MytodoDbContext(DbContextOptions<MytodoDbContext> options) : base(options){}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MytodoDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}