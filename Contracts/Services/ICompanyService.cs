using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Services;
public interface ICompanyService : IService<Company>
{
    string getBase64(IFormFile imageFile);
    Task<IEnumerable<Company>> GetCompaniesByUserAsync(int userId);
}