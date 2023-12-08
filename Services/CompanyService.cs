using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Enums;
using AppAgendamentos.Models;
using AppAgendamentos.Services.Base;

namespace AppAgendamentos.Services;
public class CompanyService : Service<Company>, ICompanyService
{
    public CompanyService(IRepository<Company> repositoryBase) : base(repositoryBase)
    {
    }
    public override Task SaveAsync(Company entity)
    {
        try
        {
            if (!entity.IsVirtual && !entity.CityId.HasValue)
                throw new ArgumentException("City is required");

            foreach (var category in entity.CategoryIds)
                entity.Categories.Add(new CompanyCategory() { CategoryId = (CategoryEnum)category });

            foreach (var serviceOffered in entity.ServicesOfferedIds)
                entity.ServicesOffered.Add(new ServicesOffered() { Id = serviceOffered });

            return base.SaveAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}