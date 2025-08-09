using OmdhSoft.Tasky.Modules.Shared.Domain.Events;

namespace OmdhSoft.Tasky.Modules.Shared.Domain.Auditing;

public interface IFullAuditableWithEvent<TId> : IFullAuditable<TId>
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get;  }
    void AddDomainEvent(IDomainEvent domainEvent);
    void ClearDomainEvents();
}

public abstract class FullAuditableWithEvent<Tkey> : IFullAuditableWithEvent<Tkey>
{
    public Tkey Id { get; protected set; } = default!;
    protected List<IDomainEvent> _domainEvents { get; set; } = new();
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }
    public Guid CreatedByUserId { get; protected set; }
    public Guid? DeletedByUserId { get; protected set; }
    public Guid? UpdatedByUserId { get; protected set; }

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.ToList(); 

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents ??= new();  
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}