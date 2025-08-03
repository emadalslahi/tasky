using Microsoft.EntityFrameworkCore;
using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Database
{
    public sealed class TaskyDbContext(DbContextOptions<TaskyDbContext> options):DbContext(options)
    {


        internal DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schemas.Tasks); // Set the default schema for the Tasks module
        }
    }
}
