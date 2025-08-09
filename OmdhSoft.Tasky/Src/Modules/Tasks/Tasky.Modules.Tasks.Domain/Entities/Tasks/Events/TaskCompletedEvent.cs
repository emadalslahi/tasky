using OmdhSoft.Tasky.Modules.Shared.Domain.Events;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Tasks.Events;

public sealed class TaskCompletedEvent(  TaskId taskId) : DomainEvent()
{
    public TaskId TaskId { get; set; } = taskId;
}
