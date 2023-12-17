using AppAgendamentos.Infrastructure.Configurations.Base;
using AppAgendamentos.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure.Configurations;
public class CompanyOpeningHoursConfiguration : EntityBaseConfiguration<CompanyOpeningHours>
{
    public override void Configure(EntityTypeBuilder<CompanyOpeningHours> builder)
    {
        base.Configure(builder);
    }
}