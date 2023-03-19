using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAgendamentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
***REMOVED***public void Configure(EntityTypeBuilder<Company> builder)
***REMOVED***{
***REMOVED***    builder.HasMany(c=>c.ServicesOffered)
***REMOVED***    .WithOne(c=>c.Company)
***REMOVED***    .HasForeignKey(c=>c.CompanyId);
***REMOVED***}
    }
}