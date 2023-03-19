using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    public class ServicesOffered : BaseEntity
    {
***REMOVED***[Required]
***REMOVED***public string Name { get; set; }
***REMOVED***[Required]
***REMOVED***public float Price { get; set; }
***REMOVED***[Required]
***REMOVED***public int CompanyId { get; set; }
***REMOVED***public Company Company { get; set; }
    }
}