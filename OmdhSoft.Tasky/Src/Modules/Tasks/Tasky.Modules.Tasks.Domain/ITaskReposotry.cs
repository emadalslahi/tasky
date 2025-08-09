using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;
using Task = Tasky.Modules.Tasks.Domain.Entities.Tasks.Task;

namespace Tasky.Modules.Tasks.Domain;

public interface ITaskReposotry
{
    Result Insert(Task task);
}