namespace Tasky.Modules.Tasks.Application.Tasks.GetTask;

public sealed record TaskResponse
(
    Guid Id,
    string Title,
    string Description,
    int Priority,
    DateTime? DueDate,
    Guid? AssignedToUserId 
);