using Tasky.Modules.Tasks.Domain.ValueObjects;
using Task = Tasky.Modules.Tasks.Domain.Entities.Tasks.Task;

namespace Tasky.Modules.Tasks.Domain.Entities.Comments.Repos;

public interface ICommentRepository
{
    Task<Task?> GetAsync(CommentId id, CancellationToken cancellationToken = default);
    void Insert(Task entity);
    void Update(Task entity);
    IEnumerable<Comment> GetAll();
    void Delete(CommentId id);
    
}