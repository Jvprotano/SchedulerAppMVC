using AppAgendamentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppAgendamentos.Infrastructure.Configuration
{
    public class SchedulingConfiguration : IEntityTypeConfiguration<Scheduling>
    {
***REMOVED***public void Configure(EntityTypeBuilder<Scheduling> builder)
***REMOVED***{
***REMOVED***    builder.ToTable("schedulings");

***REMOVED***    builder.Property(c=>c.Company)
***REMOVED******REMOVED***.HasColumnName("company_id")
***REMOVED******REMOVED***.IsRequired();

***REMOVED***    builder.Property(c=>c.Customer)
***REMOVED******REMOVED***.HasColumnName("customer_id")
***REMOVED******REMOVED***.IsRequired();
***REMOVED******REMOVED***
***REMOVED***    builder.Property(c=>c.ScheduledDate).IsRequired();
***REMOVED***}
    }
}