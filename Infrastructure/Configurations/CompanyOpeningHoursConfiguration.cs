using AppAgendamentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure.Configurations
{
    public class CompanyOpeningHoursConfiguration : IEntityTypeConfiguration<CompanyOpeningHours>
    {
public void Configure(EntityTypeBuilder<CompanyOpeningHours> builder)
{
}
    }
}