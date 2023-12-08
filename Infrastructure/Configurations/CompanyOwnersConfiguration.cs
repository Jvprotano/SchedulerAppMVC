using AppAgendamentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure.Configurations
{
    public class CompanyOwnersConfiguration : IEntityTypeConfiguration<CompanyOwners>
    {
public void Configure(EntityTypeBuilder<CompanyOwners> builder)
{

}
    }
}