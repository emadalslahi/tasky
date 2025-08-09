using Microsoft.EntityFrameworkCore;
using OmdhSoft.Tasky.Modules.Shared.Domain;
using Tasky.Modules.Tasks.Application.Abstractions.Data;
using Tasky.Modules.Tasks.Domain.ValueObjects;
using Task = Tasky.Modules.Tasks.Domain.Entities.Tasks.Task;
using TaskStatus = Tasky.Modules.Tasks.Domain.ValueObjects.TaskStatus;

namespace Tasky.Modules.Tasks.Infrastructure.Database
{
    public sealed class TaskyDbContext(DbContextOptions<TaskyDbContext> options) : DbContext(options),IUnitOfWork
    {
        internal DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schemas.Tasks);

            modelBuilder.Entity<Task>(builder =>
            {
                builder.Property(t => t.Id)
                    .HasConversion<TaskId>(id => id, value => new TaskId(value));
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
