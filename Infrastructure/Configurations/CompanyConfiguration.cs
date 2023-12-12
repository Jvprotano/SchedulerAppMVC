using AppAgendamentos.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure.Configurations;
public class CompanyConfiguration : ProfileConfiguration<Company>
{
    public override void Configure(EntityTypeBuilder<Company> builder)
    {
        base.Configure(builder);

        builder.HasMany(c => c.ServicesOffered)
        .WithOne(c => c.Company)
        .HasForeignKey(c => c.CompanyId);

        builder.Ignore(c => c.SelectedCategoryIds);
        builder.Ignore(c => c.SelectedServicesNames);
    }
}