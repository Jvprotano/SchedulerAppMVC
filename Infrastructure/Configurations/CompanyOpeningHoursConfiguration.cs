using Scheduler.Infrastructure.Configurations.Base;
using Scheduler.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Scheduler.Infrastructure.Configurations;
public class CompanyOpeningHoursConfiguration : EntityBaseConfiguration<CompanyOpeningHours>
{
    public override void Configure(EntityTypeBuilder<CompanyOpeningHours> builder)
    {
        base.Configure(builder);
    }
}