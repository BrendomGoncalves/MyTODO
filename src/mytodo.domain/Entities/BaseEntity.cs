namespace mytodo.domain.Entities;

public abstract class BaseEntity
{
    public DateTime CreatedAt { get; set; } = default;
    public DateTime UpdatedAt { get; set; } = default;
    public DateTime DeletedAt { get; set; } = default;
}