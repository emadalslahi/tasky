using OmdhSoft.Tasky.Modules.Shared.Domain.Events;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Tasks.Events;

public sealed class TaskDeletedEvent(TaskId taskId) : DomainEvent()
{
    public TaskId TaskId { get; set; } = taskId;
}
