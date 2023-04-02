using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.Contracts.Repository.Base;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Repository;
using AppAgendamentos.Repository.Base;
using AppAgendamentos.Services;

namespace AppAgendamentos.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
***REMOVED***public static void AddRepositories(this IServiceCollection services)
***REMOVED***{
***REMOVED***    #region Repositories
***REMOVED***    services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
***REMOVED***    services.AddScoped<ISchedulingRepository, SchedulingRepository>();
***REMOVED***    services.AddScoped<ICompanyRepository, CompanyRepository>();
***REMOVED***    services.AddScoped<ICompanyOpeningHoursRepository, CompanyOpeningHoursRepository>();
***REMOVED***    
***REMOVED***    #endregion

***REMOVED***    #region Services
***REMOVED***    services.AddScoped<ISchedulingService, SchedulingService>();

***REMOVED***    #endregion
***REMOVED***}
    }
}