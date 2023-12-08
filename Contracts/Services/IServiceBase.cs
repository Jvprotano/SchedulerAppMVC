namespace AppAgendamentos.Contracts.Services;
public interface IService<T> where T : class
{
    public Task SaveAsync(T entity);
}
