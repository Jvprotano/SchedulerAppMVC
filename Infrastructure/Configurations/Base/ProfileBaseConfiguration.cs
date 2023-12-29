using Scheduler.Models.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Scheduler.Infrastructure.Configurations.Base;
public abstract class ProfileBaseConfiguration<T> : EntityBaseConfiguration<T> where T : ProfileBase
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Ignore(c => c.ImageBase64);
    }
}