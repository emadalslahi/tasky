using System.Collections.Generic;
using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.Events;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;

public abstract class FullAuditableWithEventEntity<TId> : FullAuditableEntity<TId>, IFullAuditableWithEvent<TId>
{
    private readonly List<IDomainEvent> _domainEvents = new();
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public void AddDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
