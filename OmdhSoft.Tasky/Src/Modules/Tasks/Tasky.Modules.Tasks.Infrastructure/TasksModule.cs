using FluentValidation;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OmdhSoft.Tasky.Modules.Shared.Domain;
using Tasky.Modules.Tasks.Application.Abstractions.Data;
using Tasky.Modules.Tasks.Domain;
using Tasky.Modules.Tasks.Infrastructure.Database;
using Tasky.Modules.Tasks.Infrastructure.Database.Interceptors;
using Tasky.Modules.Tasks.Infrastructure.Tasks;
using Tasky.Modules.Tasks.Presentation.Tasks;

namespace Tasky.Modules.Tasks.Infrastructure;

public static  class TasksModule
{
    /// <summary>
    /// Maps the endpoints for the Tasks module.
    /// </summary>
    /// <param name="app"></param>
    public static void MapEndpoints(IEndpointRouteBuilder app)
    {
        TaskEndpoints.MapEndpoints(app); 
    }

    public static IServiceCollection AddTasksModule(this IServiceCollection services ,IConfiguration configuration)
    {
        // Register the DbContext and other services related to the Tasks module here
        // services.AddDbContext<TaskyDbContext>(options => ...);
        // services.AddScoped<ITaskService, TaskService>();

        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblies(Tasky.Modules.Tasks.Application.AssemblyReference.Assembly);
        });

        
        services.AddValidatorsFromAssembly(Tasky.Modules.Tasks.Application.AssemblyReference.Assembly,
            includeInternalTypes: true);
        
       services.AddInfrastructureServices(configuration);
        return services;
    }
    
    private static void AddInfrastructureServices(this IServiceCollection services , IConfiguration configuration)
    {
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

        services.AddScoped<ITaskReposotry, TaskReposotry>();
        services.AddScoped<IUnitOfWork>(sp=>sp.GetRequiredService<TaskyDbContext>());
    }
    
}

public static class Configs
{
    public const string TasksModuleSection = "TasksModule";
    public const string TaskyDbName = "TaskyDb";
}