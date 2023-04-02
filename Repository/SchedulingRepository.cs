using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;
using AppAgendamentos.Repository.Base;

namespace AppAgendamentos.Repository
{
    public class SchedulingRepository : RepositoryBase<Scheduling>, ISchedulingRepository
    {
***REMOVED***public SchedulingRepository(ApplicationDbContext context) : base(context)
***REMOVED***{
***REMOVED***}

***REMOVED***public List<Scheduling> GetAllByDate(int companyId, DateOnly date)
***REMOVED***{
***REMOVED***    return this.DbSet
***REMOVED******REMOVED***.Where(c => c.CompanyId == companyId &&
***REMOVED******REMOVED***c.ScheduledDate.Date == date.ToDateTime(TimeOnly.Parse("10:00 PM")).Date)
***REMOVED******REMOVED***.ToList();
***REMOVED***}
    }
}