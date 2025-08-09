using FluentValidation;
using OmdhSoft.Tasky.Modules.Shared.Domain.Messaging;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Application.Tasks.CreateTask;


public sealed record CreateTaskCommand(
string Title,
string Description,
int Priority ,
DateTime? DueDate ,
DateTime StarDateTime,
Guid? AssignedToUserId
) : ICommand<TaskId>;

internal sealed class CreateTaskValidator : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskValidator()
    {
     RuleFor(c=>c.Title).NotEmpty();
     RuleFor(c=>c.Description).NotEmpty();
     RuleFor(c=>c.Priority).InclusiveBetween(1,5);
     //RuleFor(c=>c.DueDate).LessThanOrEqualTo(DateTime.Now);
     RuleFor(c => c.AssignedToUserId).NotEmpty();
     
     RuleFor(c=>c.DueDate).Must(c=>c.HasValue).When(c=>c.DueDate.HasValue); 
     
    }
}