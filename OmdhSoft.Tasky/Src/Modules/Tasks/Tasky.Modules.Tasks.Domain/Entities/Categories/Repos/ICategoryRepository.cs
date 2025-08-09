using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Categories.Repos;

public interface ICategoryRepository
{
    Task<Category?> GetAsync(CategoryId id, CancellationToken cancellationToken = default);

    void Insert(Category category);
}