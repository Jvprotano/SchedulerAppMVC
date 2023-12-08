using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repositories
{
    public interface ICompanyOpeningHoursRepository
    {
List<CompanyOpeningHours> GetByDayOfWeek(int companyId, DayOfWeek dayOfWeek);
    }
}