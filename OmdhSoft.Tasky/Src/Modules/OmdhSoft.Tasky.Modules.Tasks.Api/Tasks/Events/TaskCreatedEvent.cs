using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.ValueObjects;
using System;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.Events;

public sealed record TaskCreatedEvent(TaskId Id, TaskTitle Title) : IDomainEvent
{
    public DateTime OccuredAt { get; set; }

}