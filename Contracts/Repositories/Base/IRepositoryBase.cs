namespace AppAgendamentos.Contracts.Repositories.Base
{
    public interface IRepositoryBase<T> where T : class
    {
***REMOVED***Task SaveAsync(T entity);
    }
}