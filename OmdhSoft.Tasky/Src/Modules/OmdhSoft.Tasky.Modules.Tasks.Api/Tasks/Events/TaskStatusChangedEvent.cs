using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.ValueObjects;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.Events;

public sealed record TaskStatusChangedEvent(TaskId Id, TaskStatus Status) : IDomainEvent;
