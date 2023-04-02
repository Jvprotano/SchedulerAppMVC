using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    [Table("schedulings")]
    public class Scheduling : BaseEntity
    {
***REMOVED***public int CompanyId { get; set; }
***REMOVED***public Company Company { get; set; }
***REMOVED***public int CustomerId { get; set; }
***REMOVED***public User Customer { get; set; }
***REMOVED***public DateTime ScheduledDate { get; set; }

***REMOVED***public int ServicesOfferedId { get; set; }
***REMOVED***public ServicesOffered ServicesOffered { get; set; }
    }
}