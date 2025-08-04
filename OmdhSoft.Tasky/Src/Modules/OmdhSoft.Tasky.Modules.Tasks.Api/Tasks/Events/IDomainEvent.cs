using System;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.Events;

public interface IDomainEvent
{
    public DateTime OccuredAt { get; set; }
}
