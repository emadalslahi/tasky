using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Tasks.Repos;

public interface ITaskRepository
{
    Task<Task?> GetAsync(TaskId id, CancellationToken cancellationToken = default);
    void Insert(Task category);
    void Update(Task category);
    IEnumerable<Task> GetAll();
    void Delete(TaskId id);
    
}