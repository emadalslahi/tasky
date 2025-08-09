using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;
using OmdhSoft.Tasky.Modules.Shared.Domain.Auditing;
using Tasky.Modules.Tasks.Domain.Entities.Tasks.Errors;
using Tasky.Modules.Tasks.Domain.Entities.Tasks.Events;
using Tasky.Modules.Tasks.Domain.ValueObjects;
using TaskStatus = Tasky.Modules.Tasks.Domain.ValueObjects.TaskStatus;

namespace Tasky.Modules.Tasks.Domain.Entities.Tasks
{
    public class Task : FullAuditableWithEvent<TaskId>
    {
        public TaskTitle Title { get; private set; }
        public TaskDescription Description { get; private set; }
        public TaskPriority Priority { get; private set; }
        public TaskStatus Status { get; private set; }
        public DateTime? DueDate { get; private set; }
        public Guid? AssignedToUserId { get; private set; }
        public DateTime StarDateTime { get; private set; }

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

        public static Result<Task> Create(
                                  TaskTitle title, 
                                  TaskDescription description, 
                                  TaskPriority priority,
                                  DateTime startDate,
                                  DateTime? dueDate,
                                  Guid assigedToUserId, 
                                  Guid taskListId
                                  )
        {
           
            if (dueDate != null && dueDate <= DateTime.UtcNow)
            {
                return Result.Failure<Task>(TaskErrors.TaskInThePastDate);
            }
            
            if (dueDate != null && dueDate < startDate)
            {
                return Result.Failure<Task>(TaskErrors.StartDateBeforeTaskDueDate);
            }
            
            Task task = new Task();
            task.Title = title;
            task.Description = description;
            task.Priority = priority;
            task.AssignedToUserId = assigedToUserId;
            task.CreatedAt = DateTime.UtcNow;
            task.Status=TaskStatus.Pending;
            task.DueDate = dueDate;
            task.StarDateTime = startDate;
            
            return Result.Success(task);
        }

        public Result Update(TaskTitle title, TaskDescription description, TaskPriority priority, Guid updatedByUserId)
        {
            Title = title;
            Description = description;
            Priority = priority;
            UpdatedAt = DateTime.UtcNow;
            UpdatedByUserId = updatedByUserId;
            AddDomainEvent(new TaskUpdatedEvent(Id));
            return Result.Success();
        }

        public Result ChangeStatus(TaskStatus status, Guid updatedByUserId)
        {
            if (Status == status)
            {
                return Result.Success();
            }

            Status = status;
            UpdatedAt = DateTime.UtcNow;
            UpdatedByUserId = updatedByUserId;
            AddDomainEvent(new TaskStatusChangedEvent(Id, status));

            if (status == TaskStatus.Completed)
            {
                AddDomainEvent(new TaskCompletedEvent(Id));
            }
            return Result.Success();
        }

        public Result Delete(Guid deletedByUserId)
        {
            if (DeletedAt is not null)
            {
                return Result.Success();
                
            }

            DeletedAt = DateTime.UtcNow;
            DeletedByUserId = deletedByUserId;
            Status = TaskStatus.Removed;
            AddDomainEvent(new TaskDeletedEvent(Id));
            return Result.Success();
        }

        public Result ReOpenTask( Guid reOpenedByUserId)
        {
            Status=TaskStatus.ReOpenned;
            UpdatedAt = DateTime.UtcNow;
            UpdatedByUserId = reOpenedByUserId;
            AddDomainEvent(new TaskStatusChangedEvent(Id, Status));
            return Result.Success();
        }

        
    }
}
