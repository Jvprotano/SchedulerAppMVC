using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    [Table("users")]
    public class User : BaseEntity
    {
***REMOVED***[Required]
***REMOVED***public string? Name { get; set; }

***REMOVED***[Required]
***REMOVED***public DateTime BirthDate { get; set; }

***REMOVED***public ICollection<Company> Companies { get; set; }
    }
}