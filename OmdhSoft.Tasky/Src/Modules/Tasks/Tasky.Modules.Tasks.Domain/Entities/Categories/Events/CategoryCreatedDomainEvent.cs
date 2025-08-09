using OmdhSoft.Tasky.Modules.Shared.Domain.Events;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Categories.Events;

public sealed class CategoryCreatedDomainEvent(CategoryId categoryId) : DomainEvent
{
    public CategoryId CategoryId { get; init; } = categoryId;
}