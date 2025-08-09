using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;
using Tasky.Modules.Tasks.Domain;
using Tasky.Modules.Tasks.Infrastructure.Database;
using Task = Tasky.Modules.Tasks.Domain.Entities.Tasks.Task;

namespace Tasky.Modules.Tasks.Infrastructure.Tasks;

internal sealed class TaskReposotry(TaskyDbContext context) :ITaskReposotry
{
    public Result Insert(Task task)
    {
        try
        {
            context.Tasks.Add(task);
        return Result.Success();    
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Result.Failure(Error.Problem("InsertException", e.Message));
        }
    }
}