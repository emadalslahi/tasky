using OmdhSoft.Tasky.Modules.Shared.Domain.Auditing;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Attachments;

public class Attachment:FullAuditableWithEventEntity<AttachmentId>
{
    public string FileName { get; set; }=string.Empty;
    public string FilePath { get; set; }=string.Empty;    
    public string FileType { get; set; }=string.Empty;
    public TaskId TaskId { get; set; }
}