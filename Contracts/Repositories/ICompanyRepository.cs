using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
Task<IEnumerable<Company>> GetAllAsync();
Task<Company> GetAsync(int id);
    }
}