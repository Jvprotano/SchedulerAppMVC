using AppAgendamentos.Enums;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    public class CompanyOpeningHours : BaseEntity
    {
public int CompanyId { get; set; }
public Company Company { get; set; }
public DayOfWeek DayOfWeek { get; set; }
public TimeSpan OpeningHour { get; set; }
public TimeSpan ClosingHour { get; set; }
    }
}