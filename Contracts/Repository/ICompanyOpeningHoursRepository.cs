using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repository
{
    public interface ICompanyOpeningHoursRepository
    {
***REMOVED***List<CompanyOpeningHours> GetByDayOfWeek(int companyId, DayOfWeek dayOfWeek);
    }
}