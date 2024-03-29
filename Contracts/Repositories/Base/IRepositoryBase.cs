using Scheduler.Models.Base;

namespace Scheduler.Contracts.Repositories.Base;
public interface IRepository<T>
{
    Task SaveAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(bool active = true);
    Task<T> GetByIdAsync(int id, bool active = true);
    Task<T> GetAsync(int id, bool active = true);
}