using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;
using Tasky.Modules.Tasks.Application.Tasks.CreateTask;
using Tasky.Modules.Tasks.Domain.ValueObjects;
using Tasky.Modules.Tasks.Presentation.ApiResults;

namespace Tasky.Modules.Tasks.Presentation.Tasks
{
    internal static class CreateTask
    {

        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/tasks", async (CreateTaskRequest request, ISender  sender) =>
            {
                var command = new CreateTaskCommand(
                    request.Title,
                    request.Description, 
                    request.Priority, 
                    request.DueDate, 
                    request.StartDate,
                    request.AssignedToUserId
                    );
                
                Result<TaskId> result = await sender.Send(command);
                return result.Match(Results.Ok, ApiResults.ApiResults.Problem);
                
            }).WithTags(Tags.Tasks);
        }

    }
}
