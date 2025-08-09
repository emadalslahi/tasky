using Microsoft.AspNetCore.Routing;

namespace Tasky.Modules.Tasks.Presentation.Tasks;

public static class TaskEndpoints
{
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateTask.MapEndpoint(app);
        GetTask.MapEndpoint(app);
    }
}