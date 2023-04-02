using AppAgendamentos.Contracts.Repository.Base;
using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repository
{
    public interface ISchedulingRepository : IRepositoryBase<Scheduling>
    {
***REMOVED***List<Scheduling> GetAllByDate(int companyId, DateOnly date);
    }
}