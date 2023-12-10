using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Enums;
using AppAgendamentos.Models;
using AppAgendamentos.Services.Base;

namespace AppAgendamentos.Services;
public class CompanyService : Service<Company>, ICompanyService
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IOpenAIService _openAIService;
    public CompanyService(IRepository<Company> repositoryBase, ICompanyRepository companyRepository, IOpenAIService openAIService) : base(repositoryBase)
    {
        _companyRepository = companyRepository;
        _openAIService = openAIService;
    }
    public override void Validate(Company entity)
    {
        if (!entity.IsVirtual && !entity.CityId.HasValue)
            throw new ArgumentException("City is required");
        if (String.IsNullOrWhiteSpace(entity.Description))
            throw new ArgumentException("Description is required");
        if (String.IsNullOrWhiteSpace(entity.Name))
            throw new ArgumentException("Name is required");
        if (String.IsNullOrWhiteSpace(entity.Email))
            throw new ArgumentException("Email is required");
    }
    public override async Task SaveAsync(Company entity)
    {
        try
        {
            entity.CityId = 2;
            this.Validate(entity);

            if (entity.Id == 0)
            {
                foreach (var category in entity.SelectedCategoryIds)
                    entity.Categories.Add(new CompanyCategory() { CategoryId = (CategoryEnum)category });

                foreach (var serviceOffered in entity.SelectedServicesNames)
                    entity.ServicesOffered.Add(new CompanyServiceOffered() { Name = serviceOffered.ToString(), Price = 0 });
            }

            // string categories = string.Join(",", entity.Categories.Select(c => ((CategoryEnum)c.CompanyId).ToString()));
            // string context = $"categories: {categories}";

            string prompt = @$"Generate a creative logo for a company called {entity.Name}. The company is {entity.Description}.The logo should reflect the following categories: {String.Join(",", entity.Categories.Select(c => ((CategoryEnum)c.CategoryId).ToString()))}. Please generate a logo that is unique, memorable, and visually appealing.";

            entity.ImageUrl = await _openAIService.GetUrlNewImageAsync(prompt.Replace("\n", " ").Replace("  ", ""));

            await base.SaveAsync(entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}