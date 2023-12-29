using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Contracts.Services;
public interface IService<T> where T : EntityBase
{
    public Task SaveAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(bool active = true);
    Task<T> GetByIdAsync(int id, bool active = true);
    Task<T> GetAsync(int id, bool active = true);
}
