using AppAgendamentos.Infrastructure.Configurations.Base;
using AppAgendamentos.Models;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure.Configurations;
public class UserConfiguration : ProfileBaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.Ignore(c => c.ConfirmPassword);
    }
}