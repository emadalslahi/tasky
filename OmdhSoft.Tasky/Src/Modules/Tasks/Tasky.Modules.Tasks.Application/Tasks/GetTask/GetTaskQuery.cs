using OmdhSoft.Tasky.Modules.Shared.Domain.Messaging;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Application.Tasks.GetTask;

public sealed record GetTaskQuery(TaskId Id) :IQuery<TaskResponse?>;