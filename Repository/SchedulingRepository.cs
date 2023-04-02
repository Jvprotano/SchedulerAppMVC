using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;

namespace AppAgendamentos.Repository
{
    public class SchedulingRepository : ISchedulingRepository
    {
***REMOVED***private readonly ApplicationDbContext _context;

***REMOVED***public SchedulingRepository(ApplicationDbContext context)
***REMOVED***{
***REMOVED***    _context = context;
***REMOVED***}

***REMOVED***public List<Scheduling> GetAllByDate(int companyId, DateOnly date)
***REMOVED***{
***REMOVED***    return this._context.Schedulings
***REMOVED******REMOVED***.Where(c => c.CompanyId == companyId &&
***REMOVED******REMOVED***c.ScheduledDate.Date == date.ToDateTime(TimeOnly.Parse("10:00 PM")).Date)
***REMOVED******REMOVED***.ToList();
***REMOVED***}
    }
}