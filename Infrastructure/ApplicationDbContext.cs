using AppAgendamentos.Infrastructure.Extensions;
using AppAgendamentos.Models.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AppAgendamentos.Infrastructure;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        modelBuilder.ApplySnakeCaseNamingConvention();

        base.OnModelCreating(modelBuilder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateDefaultValues();
        return await base.SaveChangesAsync(cancellationToken);
    }
    private void UpdateDefaultValues()
    {
        var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (
    e.State == EntityState.Added || e.State == EntityState.Modified));

        foreach (var entry in entries)
        {
            var entity = (BaseEntity)entry.Entity;
            var now = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
                entity.RegisterDate = now;

            if (!entity.Status.HasValue)
                entity.Status = Enums.StatusEnum.Active;

            entity.UpdateDate = now;
        }
    }
}