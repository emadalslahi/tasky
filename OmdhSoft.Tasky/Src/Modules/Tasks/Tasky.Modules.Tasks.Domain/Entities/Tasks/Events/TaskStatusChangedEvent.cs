using OmdhSoft.Tasky.Modules.Shared.Domain.Events;
using Tasky.Modules.Tasks.Domain.ValueObjects;
using TaskStatus = Tasky.Modules.Tasks.Domain.ValueObjects.TaskStatus;

namespace Tasky.Modules.Tasks.Domain.Entities.Tasks.Events;

public sealed class TaskStatusChangedEvent( TaskId taskId, TaskStatus status) : DomainEvent()
{
  public TaskId TaskId { get; set; } = taskId;
  public TaskStatus Status { get; set; } = status;
}