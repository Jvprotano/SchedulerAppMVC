namespace AppAgendamentos.Contracts.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
Task SaveAsync(T entity);
    }
}