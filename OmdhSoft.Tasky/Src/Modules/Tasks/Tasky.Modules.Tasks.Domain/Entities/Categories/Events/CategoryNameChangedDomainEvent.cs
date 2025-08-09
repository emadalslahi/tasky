using OmdhSoft.Tasky.Modules.Shared.Domain.Events;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Categories.Events;

public sealed class CategoryNameChangedDomainEvent(CategoryId categoryId, string name) : DomainEvent
{
    public CategoryId CategoryId { get; init; } = categoryId;

    public string Name { get; init;  } = name;
}