using AppAgendamentos.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure.Configurations;
public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasMany(c => c.ServicesOffered)
        .WithOne(c => c.Company)
        .HasForeignKey(c => c.CompanyId);

        builder.Ignore(c => c.SelectedCategoryIds);
        builder.Ignore(c => c.SelectedServicesNames);
    }
}