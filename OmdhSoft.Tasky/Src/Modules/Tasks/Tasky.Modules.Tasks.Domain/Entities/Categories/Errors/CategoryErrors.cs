using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Domain.Entities.Categories.Errors;

public static class CategoryErrors
{
    public static Error NotFound(CategoryId categoryId) =>
        Error.NotFound("Categories.NotFound", $"The category with the identifier {categoryId.Value} was not found");

    public static readonly Error AlreadyArchived = Error.Problem(
        "Categories.AlreadyArchived",
        "The category was already archived");
}