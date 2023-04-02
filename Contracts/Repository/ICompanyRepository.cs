using AppAgendamentos.Contracts.Repository.Base;
using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repository
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
***REMOVED***Task<IEnumerable<Company>> GetAllAsync();
***REMOVED***Task<Company> GetAsync(int id);
    }
}