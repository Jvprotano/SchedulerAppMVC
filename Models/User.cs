using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models;
[Table("users")]
public class User : ProfileBase
{
    [Required]
    public DateTime BirthDate { get; set; }
    public string CPF { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public ICollection<CompanyOwners> Companies { get; set; }
}