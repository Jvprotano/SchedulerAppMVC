using AppAgendamentos.Infrastructure.Configurations.Base;
using AppAgendamentos.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure.Configurations;
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