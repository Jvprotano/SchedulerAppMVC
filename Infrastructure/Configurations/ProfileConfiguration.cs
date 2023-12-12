using AppAgendamentos.Models.Base;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure.Configurations;
public abstract class ProfileConfiguration<T> : IEntityTypeConfiguration<T> where T : Profile
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.Ignore(c => c.ImageBase64);
    }
}