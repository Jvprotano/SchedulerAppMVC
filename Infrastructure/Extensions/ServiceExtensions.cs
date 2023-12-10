using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Repository;
using AppAgendamentos.Repository.Base;
using AppAgendamentos.Services;
using AppAgendamentos.Services.Base;

namespace AppAgendamentos.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
public static void AddRepositories(this IServiceCollection services)
{
    #region Repositories
    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    services.AddScoped(typeof(IService<>), typeof(Service<>));

    services.AddScoped<ISchedulingRepository, SchedulingRepository>();
    services.AddScoped<ICompanyRepository, CompanyRepository>();
    services.AddScoped<ICompanyOpeningHoursRepository, CompanyOpeningHoursRepository>();
    services.AddScoped<ICompanyService, CompanyService>();
    services.AddScoped<IOpenAIService, OpenAIService>();
    #endregion

    #region Services
    services.AddScoped<ISchedulingService, SchedulingService>();

    #endregion
}
    }
}