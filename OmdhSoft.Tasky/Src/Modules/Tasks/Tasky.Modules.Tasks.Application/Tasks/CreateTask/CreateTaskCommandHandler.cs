using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;
using OmdhSoft.Tasky.Modules.Shared.Domain.Messaging;
using Tasky.Modules.Tasks.Application.Abstractions.Data;
using Tasky.Modules.Tasks.Domain;
using Tasky.Modules.Tasks.Domain.ValueObjects;
using Task = Tasky.Modules.Tasks.Domain.Entities.Tasks.Task;

namespace Tasky.Modules.Tasks.Application.Tasks.CreateTask;

internal sealed  class CreateTaskCommandHandler(ITaskReposotry reposotry,IUnitOfWork unitOfWork ) :
        ICommandHandler<CreateTaskCommand, TaskId>
{

      
    public async Task<Result<TaskId>> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
    {
        Result<Task> task = Task.Create(
            title:request.Title,
            description:request.Description,
            priority:request.Priority,
            dueDate: request.DueDate,
            startDate: request.StarDateTime,
            taskListId:Guid.Empty,
            assigedToUserId: request.AssignedToUserId ?? Guid.Empty
        );
        if(!task.IsSuccess)
            return Result.Failure<TaskId>(task.Error);
        
        Result result = reposotry.Insert(task.Value);
        if(!result.IsSuccess)
            return Result.Failure<TaskId>(task.Error);

        if ( await unitOfWork.SaveChangesAsync(cancellationToken) == 0)
        {
            return Result.Failure<TaskId>(Error.Problem("UnSaved","Unable to create task"));
        }
        
        return Result.Success(task.Value.Id);
            
    }
}