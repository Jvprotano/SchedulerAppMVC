using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repositories
{
    public interface ISchedulingRepository : IRepository<Scheduling>
    {
        List<Scheduling> GetAllByDate(int companyId, DateOnly date);
    }
}