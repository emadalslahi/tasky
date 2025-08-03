using Microsoft.EntityFrameworkCore;
using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks;
using OmdhSoft.Tasky.Modules.Tasks.Api.Tasks.ValueObjects;

namespace OmdhSoft.Tasky.Modules.Tasks.Api.Database
{
    public sealed class TaskyDbContext(DbContextOptions<TaskyDbContext> options) : DbContext(options)
    {
        internal DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schemas.Tasks);

            modelBuilder.Entity<Task>(builder =>
            {
                builder.Property(t => t.Id)
                    .HasConversion(id => id.Value, value => new TaskId(value));
                builder.Property(t => t.Title)
                    .HasConversion(title => title.Value, value => TaskTitle.From(value));
                builder.Property(t => t.Description)
                    .HasConversion(description => description.Value, value => TaskDescription.From(value));
                builder.Property(t => t.Priority)
                    .HasConversion(priority => priority.Value, value => TaskPriority.From(value));
                builder.Property(t => t.Status)
                    .HasConversion(status => status.Value, value => TaskStatus.From(value));
            });
        }
    }
}
