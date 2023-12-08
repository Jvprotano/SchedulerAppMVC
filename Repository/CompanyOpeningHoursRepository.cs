using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Infrastructure;
using AppAgendamentos.Models;
using AppAgendamentos.Repository.Base;

using Microsoft.EntityFrameworkCore;

namespace AppAgendamentos.Repository
{
    public class CompanyOpeningHoursRepository : RepositoryBase<CompanyOpeningHours>, ICompanyOpeningHoursRepository
    {
***REMOVED***public CompanyOpeningHoursRepository(ApplicationDbContext context) 
***REMOVED***: base(context)
***REMOVED***{
***REMOVED***}

***REMOVED***public List<CompanyOpeningHours> GetAll(int companyId)
***REMOVED***{
***REMOVED***    return this.DbSet.Where(c => c.CompanyId == companyId).ToList();
***REMOVED***}
***REMOVED***public List<CompanyOpeningHours> GetByDayOfWeek(int companyId, DayOfWeek dayOfWeek)
***REMOVED***{
***REMOVED***    return this.DbSet
***REMOVED******REMOVED***    .Include(c => c.Company).ThenInclude(c=> c.ServicesOffered)
***REMOVED******REMOVED***    .Where(c => c.CompanyId == companyId && c.DayOfWeek == dayOfWeek)
***REMOVED******REMOVED***    .ToList();
***REMOVED***}
    }
}