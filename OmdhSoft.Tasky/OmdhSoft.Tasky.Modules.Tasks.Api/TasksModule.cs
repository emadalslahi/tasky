

using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmdhSoft.Tasky.Modules.Tasks.Api.Database;

namespace OmdhSoft.Tasky.Modules.Tasks.Api;

public static  class TasksModule
{
    /// <summary>
    /// Maps the endpoints for the Tasks module.
    /// </summary>
    /// <param name="app"></param>
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        CreateTask.MapEndpoint(app);
        GetTask.MapEndpoint(app);
        //GetTasksByListId.MapEndpoint(app);
        //UpdateTask.MapEndpoint(app);
        //DeleteTask.MapEndpoint(app);
    }

    public static IServiceCollection AddTasksModule(this IServiceCollection services ,IConfiguration configuration)
    {
        // Register the DbContext and other services related to the Tasks module here
        // services.AddDbContext<TaskyDbContext>(options => ...);
        // services.AddScoped<ITaskService, TaskService>();

        string connectionString = configuration.GetConnectionString(Configs.TaskyDbName)!;

        services.AddDbContext<TaskyDbContext>(options =>
            options.UseSqlServer(connectionString,
            options=> options.MigrationsHistoryTable(HistoryRepository.DefaultTableName,Schemas.Tasks))
            .UseSnakeCaseNamingConvention()
            );    

        return services;
    }
}

public static class Configs
{
    public const string TasksModuleSection = "TasksModule";
    public const string TaskyDbName = "TaskyDb";
}