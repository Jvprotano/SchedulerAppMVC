using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Contracts.Repositories.Base;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Models;
using AppAgendamentos.Services.Base;

namespace AppAgendamentos.Services;
public class SchedulingService : Service<Scheduling>, ISchedulingService
{
    private readonly ISchedulingRepository _repositoryScheduling;
    private readonly ICompanyOpeningHoursRepository _repositoryCompanyOpeningHours;

    public SchedulingService(IRepository<Scheduling> repositoryBase, ISchedulingRepository repositoryScheduling,
    ICompanyOpeningHoursRepository repositoryCompanyOpeningHours) : base(repositoryBase)
    {
        _repositoryScheduling = repositoryScheduling;
        _repositoryCompanyOpeningHours = repositoryCompanyOpeningHours;
    }
    public async Task<IEnumerable<TimeSpan>> GetAvailableTimesAsync(int companyId, int? serviceSelected, DateOnly date)
    {
        List<CompanyOpeningHours> openingHours = _repositoryCompanyOpeningHours.GetByDayOfWeek(companyId, date.DayOfWeek);

        List<TimeSpan> availableTimes = new List<TimeSpan>();

        if (openingHours.Count > 0)
        {
            Company company = openingHours?.FirstOrDefault()?.Company;

            CompanyServiceOffered serviceOffered = company.ServicesOffered.Where(c => c.Id == serviceSelected).FirstOrDefault();

            var shortestService = company.ServicesOffered.Select(c => c.Duration).Min();


            foreach (var item in openingHours)
            {
                var opening = item.OpeningHour;
                var closing = item.ClosingHour;

                while (opening <= closing - serviceOffered.Duration)
                {
                    availableTimes.Add(opening);
                    opening = opening.Add(shortestService);
                }
            }

            List<Scheduling> busyTimes = (await _repositoryScheduling.GetAllByDateAsync(companyId, date)).ToList();

            foreach (var item in busyTimes)
            {
                var scheduledHour = item.ScheduledDate.TimeOfDay;
                var scheduledDuration = item.ServicesOffered.Duration;

                TimeSpan finalBusyTime = scheduledHour.Add(scheduledDuration);

                availableTimes.RemoveAll(c => c >= scheduledHour && c <= finalBusyTime);
            }
        }

        return availableTimes;
    }
}