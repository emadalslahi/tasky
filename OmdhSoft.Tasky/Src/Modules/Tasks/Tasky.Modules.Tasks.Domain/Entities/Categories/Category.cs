using OmdhSoft.Tasky.Modules.Shared.Domain.Auditing;
using Tasky.Modules.Tasks.Domain.Entities.Categories.Events;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Categories;

public sealed class Category : FullAuditableWithEventEntity<CategoryId>
{
    private Category()
    {
    }
    public string Name { get; private set; }

    public bool IsArchived { get; private set; }

    public static Category Create(string name)
    {
        var category = new Category
        {
            Id = Guid.NewGuid(),
            Name = name,
            IsArchived = false
        };

        category.AddDomainEvent(new CategoryCreatedDomainEvent(category.Id));

        return category;
    }

    public void Archive()
    {
        IsArchived = true;

        Raise(new CategoryArchivedDomainEvent(Id));
    }

    public void ChangeName(string name)
    {
        if (Name == name)
        {
            return;
        }

        Name = name;

        Raise(new CategoryNameChangedDomainEvent(Id, Name));
    }
}
