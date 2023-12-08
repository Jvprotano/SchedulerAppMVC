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
***REMOVED***public static void AddRepositories(this IServiceCollection services)
***REMOVED***{
***REMOVED***    #region Repositories
***REMOVED***    services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
***REMOVED***    services.AddScoped(typeof(IService<>), typeof(Service<>));

***REMOVED***    services.AddScoped<ISchedulingRepository, SchedulingRepository>();
***REMOVED***    services.AddScoped<ICompanyRepository, CompanyRepository>();
***REMOVED***    services.AddScoped<ICompanyOpeningHoursRepository, CompanyOpeningHoursRepository>();

***REMOVED***    #endregion

***REMOVED***    #region Services
***REMOVED***    services.AddScoped<ISchedulingService, SchedulingService>();

***REMOVED***    #endregion
***REMOVED***}
    }
}