namespace ECommerce.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }

    public void SoftDelete()
    {
        if (!IsDeleted)
        {
            IsDeleted = true;
            UpdatedAt = DateTime.UtcNow;
        }
    }

    public void Restore()
    {
        if (IsDeleted)
        {
            IsDeleted = false;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}