using Microsoft.AspNetCore.Routing;
using OmdhSoft.Tasky.Modules.Tasks.Api.Database;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Tasks
{
    public static class CreateTask
    {

        public static void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("/tasks", async (CreateTaskRequest request, TaskyDbContext context) =>
            {
                var @task = Task.Create(
                    request.Title,
                    request.Description,
                    request.Priority,
                    request.AssignedToUserId ?? Guid.Empty, // Assuming this is the user creating the task
                    Guid.NewGuid() // Placeholder for TaskListId, replace with actual logic
                );
                context.Tasks.Add(@task);
                await context.SaveChangesAsync();
                return Results.Ok(task.Id);

            }).WithTags(Tags.Tasks) ;
        }

    }
}
