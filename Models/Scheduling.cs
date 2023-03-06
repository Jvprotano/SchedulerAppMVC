using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    public class Scheduling : BaseEntity
    {
***REMOVED***public int CompanyId { get; set; }
***REMOVED***public Company? Company { get; set; }
***REMOVED***
***REMOVED***public int CustomerId { get; set; }
***REMOVED***public User Customer { get; set; }

***REMOVED***public DateTime ScheduledDate { get; set; }
    }
}