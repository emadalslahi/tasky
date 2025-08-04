using System;
using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.ValueObjects;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;

public class CreateTaskRequest
{

    public string Title { get;  set; }
    public string Description { get;  set; }
    public int Priority { get;  set; }
    public DateTime? DueDate { get;  set; }
    public Guid? AssignedToUserId { get;  set; }
}