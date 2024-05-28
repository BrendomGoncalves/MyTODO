using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using mytodo.domain.Entities;

namespace mytodo.data.EntityTypeConfiguration;

public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<TaskEntity>
{
    public void Configure(EntityTypeBuilder<TaskEntity> builder)
    {
        builder.ToTable("Task");
        builder.HasKey(task => task.TaskId);

        builder.Property(task => task.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(task => task.Description)
            .HasMaxLength(500);

        builder.Property(task => task.DueDate)
            .IsRequired();

        builder.Property(task => task.Status)
            .IsRequired()
            .HasMaxLength(20)
            .HasDefaultValue("Pending");

        builder.Property(task => task.Priority)
            .IsRequired()
            .HasMaxLength(20)
            .HasDefaultValue("Medium");

        builder.HasOne(task => task.User)
            .WithMany(user => user.Tasks)
            .HasForeignKey(task => task.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}