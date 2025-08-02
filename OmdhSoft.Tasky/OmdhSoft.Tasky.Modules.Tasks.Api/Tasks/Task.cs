using System;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks
{
    public class Task //: FullAuditableEntity<Guid>
    {

        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public Guid? DeletedByUserId { get; private set; }
        public Guid? UpdatedByUserId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public TaskPriority Priority { get; private set; }
        public TaskStatus Status { get; private set; }
        public DateTime? DueDate { get; private set; }
        public Guid CreatedByUserId { get; private set; }
        public Guid? AssignedToUserId { get; private set; }
        //public Guid TaskListId { get; private set; }

        private Task() { }

        private Task(string title, string description, TaskPriority priority, Guid createdByUserId, Guid taskListId)
        {
            Title = title;
            Description = description;
            Priority = priority;
            CreatedByUserId = createdByUserId;
           // TaskListId = taskListId;
            Status = TaskStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            //AddDomainEvent(new TaskCreatedEvent(Id, Title.Value));
        }

        public static Task Create(string title, string description, TaskPriority priority, Guid createdByUserId, Guid taskListId)
        {
            return new Task(title, description, priority, createdByUserId, taskListId);
        }
    }
}