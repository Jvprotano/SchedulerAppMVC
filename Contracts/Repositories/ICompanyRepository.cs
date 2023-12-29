using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Repositories;
public interface ICompanyRepository : IRepository<Company>
{
    Task<IEnumerable<Company>> GetAllOpen();
    Task<IEnumerable<Company>> GetCompaniesByUserAsync(int userId);
    Task ReactiveAsync(int id);
    Task TemporaryDeleteAsync(int id);
}