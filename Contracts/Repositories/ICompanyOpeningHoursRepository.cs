using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repositories
{
    public interface ICompanyOpeningHoursRepository
    {
***REMOVED***List<CompanyOpeningHours> GetByDayOfWeek(int companyId, DayOfWeek dayOfWeek);
    }
}