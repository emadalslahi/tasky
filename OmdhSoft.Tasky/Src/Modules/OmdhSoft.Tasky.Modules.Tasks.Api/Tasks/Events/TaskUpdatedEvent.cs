using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.ValueObjects;
using System;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.Events;

public sealed record TaskUpdatedEvent(TaskId Id) : IDomainEvent
{
    public DateTime OccuredAt { get; set; }

}