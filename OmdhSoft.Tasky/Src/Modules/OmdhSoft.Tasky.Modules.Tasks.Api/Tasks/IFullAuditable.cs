using System;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;

public interface IFullAuditable<TId> : IAuditable<TId>
{
    DateTime CreatedAt { get; }
    DateTime? UpdatedAt { get; }
    DateTime? DeletedAt { get; }
    Guid CreatedByUserId { get; }
    Guid? UpdatedByUserId { get; }
    Guid? DeletedByUserId { get; }
}
