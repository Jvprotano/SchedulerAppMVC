using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models;
[Table("users")]
public class User : Profile
{
    [Required]
    public DateTime BirthDate { get; set; }
    public string CPF { get; set; }
    public ICollection<CompanyOwners> Companies { get; set; }
}