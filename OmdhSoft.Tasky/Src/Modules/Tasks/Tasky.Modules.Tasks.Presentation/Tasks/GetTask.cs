using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using OmdhSoft.Tasky.Modules.Shared.Domain.Abstractions;
using Tasky.Modules.Tasks.Application.Tasks.GetTask;
using Tasky.Modules.Tasks.Domain.ValueObjects;

namespace Tasky.Modules.Tasks.Presentation.Tasks
{
    internal static class GetTask
    {

        public static void MapEndpoint(IEndpointRouteBuilder app)
        {

            app.MapGet("/tasks/{id:guid}", async (Guid id, ISender sender) =>
                {
              Result<TaskResponse?> taskResponse=await  sender.Send(new GetTaskQuery(new TaskId(id)));
                  
                return taskResponse.IsSuccess ?  Results.Ok(taskResponse) :Results.NotFound() ;
                })
            .WithTags(Tags.Tasks)
            .WithName("GetTask")
            .Produces<Task>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
