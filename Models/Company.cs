using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    [Table("companies")]
    public class Company : BaseEntity
    {
***REMOVED***[Required]
***REMOVED***public string Name { get; set; }
***REMOVED***[Required]
***REMOVED***public string Description { get; set; }
***REMOVED***public string CNPJ { get; set; }
***REMOVED***public string Image { get; set; }

***REMOVED***public IList<CompanyOwners> Owners;
***REMOVED***public IList<Category> Categories;
***REMOVED***public ICollection<ServicesOffered> ServicesOffered;
    }
}