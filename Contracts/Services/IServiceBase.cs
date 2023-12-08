using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Contracts.Services;
public interface IService<T> where T : BaseEntity
{
    public Task SaveAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync(bool active = true);
    Task<T> GetByIdAsync(int id, bool active = true);
}
