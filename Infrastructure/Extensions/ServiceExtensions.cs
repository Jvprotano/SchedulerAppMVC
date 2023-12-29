using Scheduler.Contracts.HttpServices;
using Scheduler.Contracts.Repositories;
using Scheduler.Contracts.Repositories.Base;
using Scheduler.Contracts.Services;
using Scheduler.Repository;
using Scheduler.Repository.Base;
using Scheduler.Services;
using Scheduler.Services.Base;
using Scheduler.Services.HttpServices;

namespace Scheduler.Infrastructure.Extensions;
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
        #endregion
    }
}