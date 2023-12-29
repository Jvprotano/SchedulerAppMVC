using Scheduler.Contracts.Repositories.Base;
using Scheduler.Models;

namespace Scheduler.Contracts.Repositories;
public interface ICompanyRepository : IRepository<Company>
{
    Task<IEnumerable<Company>> GetAllOpen();
    Task<IEnumerable<Company>> GetCompaniesByUserAsync(int userId);
    Task ReactiveAsync(int id);
    Task TemporaryDeleteAsync(int id);
}