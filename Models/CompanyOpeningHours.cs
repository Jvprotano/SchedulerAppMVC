using Scheduler.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler.Models;
[Table("companies_opening_hours")]
public class CompanyOpeningHours : EntityBase
{
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan OpeningHour { get; set; }
    public TimeSpan ClosingHour { get; set; }
}