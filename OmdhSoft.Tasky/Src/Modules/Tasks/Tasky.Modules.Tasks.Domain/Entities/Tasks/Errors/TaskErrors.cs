using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Tasks.Errors;

public class TaskErrors
{
    public static Error NotFound(TaskId taskId) =>
        Error.NotFound("Task.NotFound", $"The Task with the identifier {taskId.Value} was not found");

    public static readonly Error AlreadyArchived = Error.Problem(
        "Task.AlreadyArchived",
        "The Task was already archived");
    
    public static readonly Error AlreadyCompleted = Error.Problem(
        "Task.AlreadyCompleted",
        "The Task was already Completed");
    
    public static readonly Error TaskInThePastDate = Error.Problem(
        "Task.PastDate",
        "The Task Due Date is in the past");    
    public static readonly Error StartDateBeforeTaskDueDate = Error.Problem(
        "Task.StartDateBeforeTaskDueDate",
        "The Task Start Date is Before Task Due Date");
}