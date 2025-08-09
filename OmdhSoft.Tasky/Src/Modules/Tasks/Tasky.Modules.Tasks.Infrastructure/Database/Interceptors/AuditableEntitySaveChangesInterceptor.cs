using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Tasky.Modules.Tasks.Infrastructure.Database.Interceptors;

public class AuditableEntitySaveChangesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
        DbContextEventData eventData,
        InterceptionResult<int> result,
        CancellationToken cancellationToken = default)
    {
        if (eventData.Context is { } context)
        {
            foreach (var entry in context.ChangeTracker.Entries()
                         .Where(e => e.Entity.GetType().GetInterfaces()
                             .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(OmdhSoft.Tasky.Modules.Shared.Domain.Auditing.IFullAuditable<>))))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                        entry.Property("CreatedByUserId").CurrentValue = Guid.Empty;
                        break;
                    case EntityState.Modified:
                        entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                        entry.Property("UpdatedByUserId").CurrentValue = Guid.Empty;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Property("DeletedAt").CurrentValue = DateTime.UtcNow;
                        entry.Property("DeletedByUserId").CurrentValue = Guid.Empty;
                        break;
                }
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}

