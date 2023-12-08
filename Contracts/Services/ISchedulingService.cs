using AppAgendamentos.Models;

namespace AppAgendamentos.Contracts.Services;
public interface ISchedulingService : IService<Scheduling>
{
    Task<IEnumerable<TimeSpan>> GetAvailableTimesAsync(int companyId, int? serviceSelected, DateOnly date);
}