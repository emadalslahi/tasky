using OmdhSoft.Tasky.Modules.Shared.Domain.Events;

namespace OmdhSoft.Tasky.Modules.Shared.Domain.Auditing;

public abstract class FullAuditableWithEventEntity<TId> : FullAuditableEntity<TId>, IFullAuditableWithEvent<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
