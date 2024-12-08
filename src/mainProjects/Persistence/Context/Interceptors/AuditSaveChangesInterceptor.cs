using Application.Services.DateTimeProviders;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Core.Domain.Entities;

namespace Persistence.Context.Interceptors;
internal class AuditSaveChangesInterceptor : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData,
                                                                          InterceptionResult<int> result,
                                                                          CancellationToken cancellationToken = default)
    {
        DbContext dbContext = eventData.Context!;

        foreach (var entry in dbContext.ChangeTracker.Entries<Entity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified))
        {
            if (entry.Entity is AuditableEntity auditable)
            {
                if (entry.State == EntityState.Added)
                {
                    auditable.CreatedDate = IDateTimeProvider.Now;
                }
                else if (entry.State == EntityState.Modified)
                {
                    auditable.UpdatedDate = IDateTimeProvider.Now;
                }
            }
        }

        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}
