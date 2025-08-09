using OmdhSoft.Tasky.Modules.Shared.Domain.Events;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Categories.Events;

public sealed class CategoryArchivedDomainEvent(CategoryId categoryId) : DomainEvent
{
    public CategoryId CategoryId { get; init; } = categoryId;
}