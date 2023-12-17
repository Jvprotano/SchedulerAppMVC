using AppAgendamentos.Contracts.HttpServices;
using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Repository;
using AppAgendamentos.Repository.Base;
using AppAgendamentos.Services;
using AppAgendamentos.Services.Base;
using AppAgendamentos.Services.HttpServices;

namespace AppAgendamentos.Infrastructure.Extensions;
public static class ServiceExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped(typeof(IService<>), typeof(Service<>));

        #region Repositories
        services.AddScoped<ISchedulingRepository, SchedulingRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ICompanyOpeningHoursRepository, CompanyOpeningHoursRepository>();
        #endregion

        #region Services
        services.AddScoped<ISchedulingService, SchedulingService>();
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<IOpenAIService, OpenAIService>();
        services.AddScoped<IImageUploadService, ImageUploadService>();
        services.AddScoped<IUserService, UserService>();
        #endregion
    }
}