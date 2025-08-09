using OmdhSoft.Tasky.Modules.Shared.Domain.Events;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Tasks.Events;

public sealed class TaskUpdatedEvent( TaskId TskId) : DomainEvent()
{
    public TaskId TskId { get; set; } = TskId;
    public DateTime OccuredAt { get; set; }

}