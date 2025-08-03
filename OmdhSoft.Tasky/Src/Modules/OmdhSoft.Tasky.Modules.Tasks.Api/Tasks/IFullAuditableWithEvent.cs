using System.Collections.Generic;
using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.Events;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;

public interface IFullAuditableWithEvent<TId> : IFullAuditable<TId>
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    void AddDomainEvent(IDomainEvent domainEvent);
    void ClearDomainEvents();
}
