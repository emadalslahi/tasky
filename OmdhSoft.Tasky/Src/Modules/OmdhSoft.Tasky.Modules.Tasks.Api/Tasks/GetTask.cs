

using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using OmdhSoft.Tasky.Modules.Tasks.Api.Database;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks
{
    public static class GetTask
    {

        public static void MapEndpoint(IEndpointRouteBuilder app)
        {

            app.MapGet("/tasks/{id:guid}", async (Guid id, TaskyDbContext context) =>
                {
                    TaskResponse? task = await context.Tasks
                        .Where(e => e.Id == id)
                        .Select(e => new TaskResponse(
                            e.Id,
                            e.Title,
                            e.Description,
                            e.Priority,
                            e.DueDate,
                            e.AssignedToUserId)).SingleOrDefaultAsync();
                return task == null ? Results.NotFound() : Results.Ok(task);
                })
            .WithTags(Tags.Tasks)
            .WithName("GetTask")
            .Produces<Task>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
        }
    }
}
