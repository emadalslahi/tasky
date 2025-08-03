using System;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;

public class CreateTaskRequest
{

    public string Title { get; private set; }
    public string Description { get; private set; }
    public TaskPriority Priority { get; private set; }
    public DateTime? DueDate { get; private set; }
    public Guid? AssignedToUserId { get; private set; }
}