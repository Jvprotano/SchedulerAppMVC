using Scheduler.Contracts.Repositories.Base;
using Scheduler.Models;

namespace Scheduler.Contracts.Repositories;
public interface ISchedulingRepository : IRepository<Scheduling>
{
    Task<IEnumerable<Scheduling>> GetAllByDateAsync(int companyId, DateOnly date);
    Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(int companyId, DateTime initialDate, DateTime finalDate);
}