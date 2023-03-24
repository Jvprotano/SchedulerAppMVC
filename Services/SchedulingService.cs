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
***REMOVED***public List<TimeSpan> GetAvailableTimes(int companyId, DateTime date)
***REMOVED***{
***REMOVED***    List<CompanyOpeningHours> openingHours = _repositoryCompanyOpeningHours.GetByDayOfWeek(companyId, date.DayOfWeek);
***REMOVED***    var company = openingHours.FirstOrDefault().Company;
***REMOVED***    
***REMOVED***    var shortestService = company.ServicesOffered.Select(c=>c.Duration).Min();
***REMOVED***    
***REMOVED***    List<TimeSpan> availableTimes = new List<TimeSpan>();

***REMOVED***    foreach (var item in openingHours)
***REMOVED***    {
***REMOVED******REMOVED***var opening = item.OpeningHour;
***REMOVED******REMOVED***var closing = item.ClosingHour;

***REMOVED******REMOVED***while (opening <= closing - shortestService)
***REMOVED******REMOVED***{
***REMOVED******REMOVED***    availableTimes.Add(opening);
***REMOVED******REMOVED***    opening = opening.Add(shortestService);
***REMOVED******REMOVED***}
***REMOVED***    }

***REMOVED***    List<Scheduling> busyTimes = _repositoryScheduling.GetAllByDate(companyId, date);

***REMOVED***    foreach(var item in busyTimes)
***REMOVED***    {
***REMOVED******REMOVED***var scheduledHour = item.ScheduledDate.TimeOfDay;
***REMOVED******REMOVED***var scheduledDuration = item.ServicesOffered.Duration;

***REMOVED******REMOVED***TimeSpan finalBusyTime = scheduledHour.Add(scheduledDuration);

***REMOVED******REMOVED***availableTimes.RemoveAll(c=>c >= scheduledHour && c <= finalBusyTime);
***REMOVED***    }

***REMOVED***    // Filtrar horários em que o próximo horário seja maior ou igual a duração do serviço selecionado
***REMOVED***    // A hora máxima é a hora de fechar - tempo para o serviço. 
***REMOVED***    return availableTimes;
***REMOVED***}
    }
}