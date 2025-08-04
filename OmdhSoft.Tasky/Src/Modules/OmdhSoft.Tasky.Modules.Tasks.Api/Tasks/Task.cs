using System;
using System.Collections.Generic;
using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.Events;
using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.ValueObjects;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks
{
    public class Task : IFullAuditableWithEvent<TaskId>
    {
        public TaskId Id { get; private set; } = TaskId.New();
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public Guid? DeletedByUserId { get; private set; }
        public Guid? UpdatedByUserId { get; private set; }
        public TaskTitle Title { get; private set; }
        public TaskDescription Description { get; private set; }
        public TaskPriority Priority { get; private set; }
        public TaskStatus Status { get; private set; }
        public DateTime? DueDate { get; private set; }
        public Guid CreatedByUserId { get; private set; }
        public Guid? AssignedToUserId { get; private set; }

        private readonly List<IDomainEvent> _domainEvents = new();
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

        private Task() { }

        private Task(TaskTitle title, TaskDescription description, TaskPriority priority, Guid createdByUserId, Guid taskListId)
        {
            Title = title;
            Description = description;
            Priority = priority;
            CreatedByUserId = createdByUserId;
            Status = TaskStatus.Pending;
            CreatedAt = DateTime.UtcNow;
            AddDomainEvent(new TaskCreatedEvent(Id, Title));
        }

        public static Task Create(TaskTitle title, 
                                  TaskDescription description, 
                                  TaskPriority priority,
                                  Guid createdByUserId, 
                                  Guid taskListId)
        {
            return new Task(title, description, priority, createdByUserId, taskListId);
        }

        public void Update(TaskTitle title, TaskDescription description, TaskPriority priority, Guid updatedByUserId)
        {
            Title = title;
            Description = description;
            Priority = priority;
            UpdatedAt = DateTime.UtcNow;
            UpdatedByUserId = updatedByUserId;
            AddDomainEvent(new TaskUpdatedEvent(Id));
        }

        public void ChangeStatus(TaskStatus status, Guid updatedByUserId)
        {
            if (Status == status)
            {
                return;
            }

            Status = status;
            UpdatedAt = DateTime.UtcNow;
            UpdatedByUserId = updatedByUserId;
            AddDomainEvent(new TaskStatusChangedEvent(Id, status));

            if (status == TaskStatus.Completed)
            {
                AddDomainEvent(new TaskCompletedEvent(Id));
            }
        }

        public void Delete(Guid deletedByUserId)
        {
            if (DeletedAt is not null)
            {
                return;
            }

            DeletedAt = DateTime.UtcNow;
            DeletedByUserId = deletedByUserId;
            Status = TaskStatus.Removed;
            AddDomainEvent(new TaskDeletedEvent(Id));
        }

        public void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}
