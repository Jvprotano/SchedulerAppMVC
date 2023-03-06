using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    [Table("companies")]
    public class Company : BaseEntity
    {
***REMOVED***[Required]
***REMOVED***public string? Name { get; set; }
***REMOVED***[Required]
***REMOVED***[ForeignKey("User")]
***REMOVED***public int UserId { get; set; }

***REMOVED***public User Owner { get; set; }
    }
}