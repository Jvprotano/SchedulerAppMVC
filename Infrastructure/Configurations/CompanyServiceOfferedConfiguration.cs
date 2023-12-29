using Scheduler.Infrastructure.Configurations.Base;
using Scheduler.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Scheduler.Infrastructure.Configurations;
public class CompanyServiceOfferedConfiguration : EntityBaseConfiguration<CompanyServiceOffered>
{
    public override void Configure(EntityTypeBuilder<CompanyServiceOffered> builder)
    {
        base.Configure(builder);

        builder.HasOne(c => c.Company)
            .WithMany(c => c.ServicesOffered)
            .HasForeignKey(c => c.CompanyId);
    }
}