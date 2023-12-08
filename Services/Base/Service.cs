using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Contracts.Services;

namespace AppAgendamentos.Services.Base;
public class Service<T> : IService<T> where T : class
{***REMOVED***       
    private readonly IRepository<T> _repositoryBase;
    public Service(IRepository<T> repositoryBase)
    {
***REMOVED***_repositoryBase = repositoryBase;
    }
    public virtual async Task SaveAsync(T entity)
    {
***REMOVED***await _repositoryBase.SaveAsync(entity);
    }
}