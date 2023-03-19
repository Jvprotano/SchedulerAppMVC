using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repository
{
    public interface ICompanyRepository
    {
***REMOVED***Task<Company> GetAsync(int id);
***REMOVED***Task Save(Company company);
    }
}