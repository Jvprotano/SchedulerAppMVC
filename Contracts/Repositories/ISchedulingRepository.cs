using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repositories;
public interface ISchedulingRepository : IRepository<Scheduling>
{
    Task<IEnumerable<Scheduling>> GetAllByDateAsync(int companyId, DateOnly date);
}