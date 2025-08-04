using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.ValueObjects;
using System;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.Events;

public sealed record TaskStatusChangedEvent(TaskId Id, TaskStatus Status) : IDomainEvent
{
    public TaskStatus OldTaskStatus { get; set; }
    public TaskStatus TaskStatus { get; set; }
    public DateTime OccuredAt { get; set; }

}
