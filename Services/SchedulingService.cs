using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Models;

namespace AppAgendamentos.Services
{
    public class SchedulingService : ISchedulingService
    {
***REMOVED***private readonly ISchedulingRepository _repositoryScheduling;
***REMOVED***private readonly ICompanyOpeningHoursRepository _repositoryCompanyOpeningHours;

***REMOVED***public SchedulingService(ISchedulingRepository repositoryScheduling, ICompanyOpeningHoursRepository repositoryCompanyOpeningHours)
***REMOVED***{
***REMOVED***    _repositoryScheduling = repositoryScheduling;
***REMOVED***    _repositoryCompanyOpeningHours = repositoryCompanyOpeningHours;
***REMOVED***}

***REMOVED***public List<TimeSpan> GetAvailableTimes(int companyId, int? serviceSelected, DateOnly date)
***REMOVED***{
***REMOVED***    List<CompanyOpeningHours> openingHours = _repositoryCompanyOpeningHours.GetByDayOfWeek(companyId, date.DayOfWeek);

***REMOVED***    List<TimeSpan> availableTimes = new List<TimeSpan>();

***REMOVED***    if (openingHours.Count > 0)
***REMOVED***    {
***REMOVED******REMOVED***Company company = openingHours?.FirstOrDefault()?.Company;

***REMOVED******REMOVED***ServicesOffered serviceOffered = company.ServicesOffered.Where(c => c.Id == serviceSelected).FirstOrDefault();

***REMOVED******REMOVED***var shortestService = company.ServicesOffered.Select(c => c.Duration).Min();


***REMOVED******REMOVED***foreach (var item in openingHours)
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    var opening = item.OpeningHour;
***REMOVED******REMOVED***    var closing = item.ClosingHour;

***REMOVED******REMOVED***    while (opening <= closing - serviceOffered.Duration)
***REMOVED******REMOVED***    {
***REMOVED******REMOVED******REMOVED***availableTimes.Add(opening);
***REMOVED******REMOVED******REMOVED***opening = opening.Add(shortestService);
***REMOVED******REMOVED***    }
***REMOVED******REMOVED***}

***REMOVED******REMOVED***List<Scheduling> busyTimes = _repositoryScheduling.GetAllByDate(companyId, date);

***REMOVED******REMOVED***foreach (var item in busyTimes)
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    var scheduledHour = item.ScheduledDate.TimeOfDay;
***REMOVED******REMOVED***    var scheduledDuration = item.ServicesOffered.Duration;

***REMOVED******REMOVED***    TimeSpan finalBusyTime = scheduledHour.Add(scheduledDuration);

***REMOVED******REMOVED***    availableTimes.RemoveAll(c => c >= scheduledHour && c <= finalBusyTime);
***REMOVED******REMOVED***}
***REMOVED***    }

***REMOVED***    return availableTimes;
***REMOVED***}
    }
}