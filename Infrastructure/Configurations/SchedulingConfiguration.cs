using AppAgendamentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure.Configurations
{
    public class SchedulingConfiguration : IEntityTypeConfiguration<Scheduling>
    {
public void Configure(EntityTypeBuilder<Scheduling> builder)
{
}
    }
}