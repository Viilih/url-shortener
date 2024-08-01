namespace Url.Domain.Entities;

public abstract class Entity
{
    protected Entity(Guid id)
    {
        Id = id;
        CreatedAt = DateTime.Now;
    }
    public Guid Id { get; init; }
    
    public DateTime CreatedAt { get; private set; }
}