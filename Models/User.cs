using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    [Table("users")]
    public class User : BaseEntity
    {
[Required]
public string Name { get; set; }

[Required]
public DateTime BirthDate { get; set; }

public ICollection<CompanyOwners> Companies { get; set; }
    }
}