using Microsoft.OpenApi.Models;
using OmdhSoft.Tasky.Modules.Tasks.Api;
using OmdhSoft.Tasky.Tasky.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder);

var app = builder.Build();

ConfigurePipeline(app);

app.Run();

static void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Tasky API",
            Version = "v1"
        });
    });

    builder.Services.AddTasksModule(builder.Configuration);
}

static void ConfigurePipeline(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasky API V1");
            c.RoutePrefix = string.Empty; // Set Swagger UI at the app's root
        });

        app.ApplyMigrations();
    }

    TasksModule.MapEndpoints(app);
}
 