using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repositories
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
***REMOVED***Task<IEnumerable<Company>> GetAllAsync();
***REMOVED***Task<Company> GetAsync(int id);
    }
}