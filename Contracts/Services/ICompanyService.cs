using Scheduler.Models;

namespace Scheduler.Contracts.Services;
public interface ICompanyService : IService<Company>
{
    Task<IEnumerable<Company>> GetAllOpen();
    string getBase64(IFormFile imageFile);
    Task<IEnumerable<Company>> GetCompaniesByUserAsync(int userId);
    Task ReactiveAsync(int id);
    Task TemporaryDeleteAsync(int id);
}