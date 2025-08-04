using System;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;

public abstract class FullAuditableEntity<TId> : IFullAuditable<TId>
{
    public TId Id { get; protected set; } = default!;
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; }
    public DateTime? DeletedAt { get; protected set; }
    public Guid CreatedByUserId { get; protected set; }
    public Guid? UpdatedByUserId { get; protected set; }
    public Guid? DeletedByUserId { get; protected set; }
}
