using AppAgendamentos.Infrastructure.Extensions;
using AppAgendamentos.Models;
using AppAgendamentos.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace AppAgendamentos.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
***REMOVED***public ApplicationDbContext(DbContextOptions options) : base(options)
***REMOVED***{
***REMOVED***}

***REMOVED***public DbSet<Company> Companies { get; set; }
***REMOVED***public DbSet<User> Users { get; set; }
***REMOVED***public DbSet<Scheduling> Schedulings { get; set; }

***REMOVED***protected override void OnModelCreating(ModelBuilder modelBuilder)
***REMOVED***{
***REMOVED***    modelBuilder.ApplySnakeCaseNamingConvention();

***REMOVED***    // modelBuilder.ApplyConfiguration(new SchedulingConfiguration());

***REMOVED***    base.OnModelCreating(modelBuilder);
***REMOVED***}

***REMOVED***public override int SaveChanges()
***REMOVED***{
***REMOVED***    AtualizarDatas();
***REMOVED***    return base.SaveChanges();
***REMOVED***}
***REMOVED***public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
***REMOVED***{
***REMOVED***    AtualizarDatas();
***REMOVED***    return await base.SaveChangesAsync(cancellationToken);
***REMOVED***}

***REMOVED***private void AtualizarDatas()
***REMOVED***{
***REMOVED***    var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (
***REMOVED******REMOVED***e.State == EntityState.Added || e.State == EntityState.Modified));

***REMOVED***    foreach (var entry in entries)
***REMOVED***    {
***REMOVED******REMOVED***var entity = (BaseEntity)entry.Entity;
***REMOVED******REMOVED***var now = DateTime.UtcNow;

***REMOVED******REMOVED***if (entry.State == EntityState.Added)
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    entity.RegisterDate = now;
***REMOVED******REMOVED***}

***REMOVED******REMOVED***entity.UpdateDate = now;
***REMOVED***    }
***REMOVED***}

    }
}