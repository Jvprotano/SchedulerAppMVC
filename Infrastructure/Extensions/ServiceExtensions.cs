using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.Repository;

namespace AppAgendamentos.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
***REMOVED***public static void AddRepositories(this IServiceCollection services)
***REMOVED***{
***REMOVED***    services.AddScoped<ISchedulingRepository, SchedulingRepository>();
***REMOVED***    services.AddScoped<ICompanyRepository, CompanyRepository>();
***REMOVED***}
    }
}