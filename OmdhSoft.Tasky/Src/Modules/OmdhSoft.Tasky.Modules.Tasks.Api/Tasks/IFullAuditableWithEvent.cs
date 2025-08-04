using System;
using System.Collections.Generic;
using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.Events;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;

public interface IFullAuditableWithEvent<TId> : IFullAuditable<TId>
{
    IReadOnlyCollection<IDomainEvent> DomainEvents { get;  }
    void AddDomainEvent(IDomainEvent domainEvent);
    void ClearDomainEvents();
}

public class FullAuditableWithEvent<Tkey> : IFullAuditableWithEvent<Tkey>
{
    public Tkey Id { get; protected set; } = default!;
    private List<IDomainEvent> _domainEvents { get; set; } = new();

    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }
    public Guid CreatedByUserId { get; protected set; }
    public Guid? DeletedByUserId { get; protected set; }
    public Guid? UpdatedByUserId { get; internal set; }

    public IReadOnlyCollection<IDomainEvent> DomainEvents { get=> _domainEvents; }

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