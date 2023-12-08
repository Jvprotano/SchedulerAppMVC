namespace AppAgendamentos.Contracts.Services
{
    public interface ISchedulingService
    {
        List<TimeSpan> GetAvailableTimes(int companyId, int? serviceSelected, DateOnly date);
    }
}