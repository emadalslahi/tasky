using Microsoft.EntityFrameworkCore;
using OmdhSoft.Tasky.Modules.Tasks.Api.Database;

namespace OmdhSoft.Tasky.Tasky.Api.Extensions
{
   internal static class MigrationExtensions
    {
        internal static void ApplayMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();
            ApplyMigrations<TaskyDbContext>(scope);
        }

        private static void ApplyMigrations<TDbContext>(this IServiceScope scope)
        where TDbContext : DbContext
        {

            using TDbContext dbContext = scope.ServiceProvider.GetRequiredService<TDbContext>();
            if (dbContext.Database.IsRelational())
            {
                dbContext.Database.Migrate();
            }
        }
    }
}
