using Microsoft.OpenApi.Models;
using OmdhSoft.Tasky.Modules.Tasks.Api;
using OmdhSoft.Tasky.Tasky.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
ConfigureMiddleware(app);

app.Run();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    // Add API documentation (Swagger)
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Tasky API",
            Version = "v1"
        });
    });

    // Add the tasks module (custom module dependency injection)
    services.AddTasksModule(configuration);
}

void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        // Enable Swagger in development
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasky API V1");
            c.RoutePrefix = string.Empty; // Expose Swagger UI at the root
        });

        // Apply migrations in development
        app.ApplayMigrations();
    }

    // Map custom endpoint routes
    TasksModule.MapEndpoints(app);
}