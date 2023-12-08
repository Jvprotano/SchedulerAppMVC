using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models;
[Table("cities")]
public class City : BaseEntity
{
    public string Name { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
}