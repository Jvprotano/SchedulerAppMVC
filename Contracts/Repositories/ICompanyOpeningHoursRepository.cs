using Scheduler.Models;

namespace Scheduler.Contracts.Repositories
{
    public interface ICompanyOpeningHoursRepository
    {
List<CompanyOpeningHours> GetByDayOfWeek(int companyId, DayOfWeek dayOfWeek);
    }
}