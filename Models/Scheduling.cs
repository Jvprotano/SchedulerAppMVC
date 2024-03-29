using Scheduler.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler.Models;
[Table("schedulings")]
public class Scheduling : EntityBase
{
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int CustomerId { get; set; }
    public ApplicationUser Customer { get; set; }
    public DateTime ScheduledDate { get; set; }
    public int ServicesOfferedId { get; set; }
    public CompanyServiceOffered ServiceOffered { get; set; }
}