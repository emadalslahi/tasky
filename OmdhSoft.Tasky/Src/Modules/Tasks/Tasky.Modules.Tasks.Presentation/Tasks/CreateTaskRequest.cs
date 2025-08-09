namespace Tasky.Modules.Tasks.Presentation.Tasks;

public sealed record CreateTaskRequest
{

    public string Title { get;  set; }
    public string Description { get;  set; }
    public int Priority { get;  set; }
    public DateTime StartDate { get;  set; }
    public DateTime? DueDate { get;  set; }
    public Guid? AssignedToUserId { get;  set; }
}