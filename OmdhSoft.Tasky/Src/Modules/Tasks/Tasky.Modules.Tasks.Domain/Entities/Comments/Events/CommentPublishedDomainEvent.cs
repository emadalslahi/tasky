using OmdhSoft.Tasky.Modules.Shared.Domain.Events;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Comments.Events;

public sealed class CommentPublishedDomainEvent(CommentId Id) : DomainEvent
{
    public CommentId CommentId { get; init; } = Id;
}