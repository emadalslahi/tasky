namespace OmdhSoft.Tasky.Modules.Shared.Domain.Events;

public interface IDomainEvent
{
    Guid Id { get;  }
    public DateTime OccuredAt { get;  }
}

public abstract class DomainEvent(Guid id, DateTime occured) : IDomainEvent
{
    protected DomainEvent(Guid id) : this(id, DateTime.Now)
    {
    }

    protected DomainEvent() : this(Guid.NewGuid(), DateTime.Now)
    {
    }
    public Guid Id { get; init; } = id;
    public DateTime OccuredAt { get; init; } = occured;
}