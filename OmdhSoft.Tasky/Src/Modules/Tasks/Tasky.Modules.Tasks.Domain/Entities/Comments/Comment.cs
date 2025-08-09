using OmdhSoft.Tasky.Modules.Shared.Domain.Auditing;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Comments;

public class Comment :FullAuditableWithEventEntity<CommentId>
{
    public Comment()
    {
        
    }
    public Comment(TaskId taskId)
    {
        TaskId = taskId;
    }
    
    public string Content { get; set; }=string.Empty;
    public CommentStatus Status { get; set; }
    public TaskId TaskId { get; set; }
}

public enum CommentStatus
{
    Draft =0,
    Published =1,
    Unpublished =2,
    Deleted =3
}