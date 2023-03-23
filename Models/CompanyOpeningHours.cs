using AppAgendamentos.Enums;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    public class CompanyOpeningHours : BaseEntity
    {
***REMOVED***public int CompanyId { get; set; }
***REMOVED***public Company Company { get; set; }
***REMOVED***public DayOfWeekEnum DayOfWeek { get; set; }
***REMOVED***public TimeSpan OpeningHour { get; set; }
***REMOVED***public TimeSpan ClosingHour { get; set; }
    }
}