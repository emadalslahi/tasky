using OmdhSoft.Tasky.Modules.Shared.Domain.Events;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Tasks.Events;

public sealed class TaskCreatedEvent(TaskId TaskId, TaskTitle Title) : DomainEvent()
{
    public TaskId TaskId { get; set; } = TaskId;
    public TaskTitle Title { get; set; } = Title;
    public DateTime OccuredAt { get; set; }

}