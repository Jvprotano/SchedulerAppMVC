using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Models;

namespace AppAgendamentos.Services
{
    public class SchedulingService : ISchedulingService
    {
private readonly ISchedulingRepository _repositoryScheduling;
private readonly ICompanyOpeningHoursRepository _repositoryCompanyOpeningHours;

public SchedulingService(ISchedulingRepository repositoryScheduling, ICompanyOpeningHoursRepository repositoryCompanyOpeningHours)
{
    _repositoryScheduling = repositoryScheduling;
    _repositoryCompanyOpeningHours = repositoryCompanyOpeningHours;
}

public void Save(Scheduling entity)
{
    // _repositoryScheduling.Save(entity);
}
public List<TimeSpan> GetAvailableTimes(int companyId, int? serviceSelected, DateOnly date)
{
    List<CompanyOpeningHours> openingHours = _repositoryCompanyOpeningHours.GetByDayOfWeek(companyId, date.DayOfWeek);

    List<TimeSpan> availableTimes = new List<TimeSpan>();

    if (openingHours.Count > 0)
    {
Company company = openingHours?.FirstOrDefault()?.Company;

ServicesOffered serviceOffered = company.ServicesOffered.Where(c => c.Id == serviceSelected).FirstOrDefault();

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

List<Scheduling> busyTimes = _repositoryScheduling.GetAllByDate(companyId, date);

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
}