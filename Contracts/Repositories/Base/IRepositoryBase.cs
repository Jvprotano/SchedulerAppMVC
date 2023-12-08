namespace AppAgendamentos.Contracts.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
***REMOVED***Task SaveAsync(T entity);
    }
}