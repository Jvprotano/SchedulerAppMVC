using Scheduler.Models;

namespace Scheduler.Contracts.Services;
public interface ISchedulingService : IService<Scheduling>
{
    Task<IEnumerable<Scheduling>> GetAllOpenByCompanyIdAsync(int companyId, DateTime initialDate, DateTime finalDate);
    Task<IEnumerable<TimeSpan>> GetAvailableTimesAsync(int companyId, int? serviceSelected, DateOnly date);
}