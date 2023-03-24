using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repository
{
    public interface ISchedulingRepository
    {
***REMOVED***List<Scheduling> GetAllByDate(int companyId, DateTime date);
    }
}