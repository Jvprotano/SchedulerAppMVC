using Scheduler.Infrastructure.Configurations.Base;
using Scheduler.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Scheduler.Infrastructure.Configurations;
public class CompanyConfiguration : ProfileBaseConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);

        builder.HasMany(c => c.Owners)
            .WithOne(c => c.Company)
            .HasForeignKey(c => c.CompanyId);

        builder.HasMany(c => c.ServicesOffered)
            .WithOne(c => c.Company)
            .HasForeignKey(c => c.CompanyId);

        builder.Ignore(c => c.SelectedCategoryIds);
        builder.Ignore(c => c.SelectedServicesNames);
    }
}