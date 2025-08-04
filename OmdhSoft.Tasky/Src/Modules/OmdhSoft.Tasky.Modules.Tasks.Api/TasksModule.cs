

using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmdhSoft.Tasky.Modules.Tasks.Api.Database;
using OmdhSoft.Tasky.Modules.Tasks.Api.Database.Interceptors;

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

        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        services.AddDbContext<TaskyDbContext>((sp, options) =>
        {
            options
                .UseSqlServer(
                    connectionString,
                    opts => opts.MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Tasks))
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(sp.GetRequiredService<AuditableEntitySaveChangesInterceptor>());
        });

        return services;
    }
}

public static class Configs
{
    public const string TasksModuleSection = "TasksModule";
    public const string TaskyDbName = "TaskyDb";
}