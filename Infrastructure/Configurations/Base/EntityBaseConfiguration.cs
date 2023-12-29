using Scheduler.Models.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Scheduler.Infrastructure.Configurations.Base;
public abstract class EntityBaseConfiguration<T> : IEntityTypeConfiguration<T> where T : EntityBase
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasQueryFilter(c => c.Status == Enums.StatusEnum.Active);
    }
}