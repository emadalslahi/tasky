using System;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;

public sealed record TaskResponse
(
    Guid Id,
    string Title,
    string Description,
    TaskPriority Priority,
    DateTime? DueDate,
    Guid? AssignedToUserId 
);