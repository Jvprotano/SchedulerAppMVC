using AppAgendamentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure.Configurations
{
    public class ServicesOfferedConfiguration : IEntityTypeConfiguration<ServicesOffered>
    {
public void Configure(EntityTypeBuilder<ServicesOffered> builder)
{
}
    }
}