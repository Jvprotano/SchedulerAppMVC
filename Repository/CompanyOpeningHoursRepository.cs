using Scheduler.Contracts.Repositories;
using Scheduler.Infrastructure;
using Scheduler.Models;
using Scheduler.Repository.Base;

namespace Scheduler.Repository;
public class CompanyOpeningHoursRepository : Repository<CompanyOpeningHours>, ICompanyOpeningHoursRepository
{
    public CompanyOpeningHoursRepository(ApplicationDbContext context)
    : base(context)
    {
    }
    public List<CompanyOpeningHours> GetAll(int companyId)
    {
        return DbSet.Where(c => c.CompanyId == companyId).ToList();
    }
    public List<CompanyOpeningHours> GetByDayOfWeek(int companyId, DayOfWeek dayOfWeek)
    {
        return DbSet
        .Where(c => c.CompanyId == companyId && c.DayOfWeek == dayOfWeek)
        .ToList();
    }
}