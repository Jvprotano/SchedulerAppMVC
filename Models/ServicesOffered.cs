using System.ComponentModel.DataAnnotations;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    public class ServicesOffered : BaseEntity
    {
[Required]
public string Name { get; set; }
[Required]
public float Price { get; set; }
[Required]
public int CompanyId { get; set; }
public Company Company { get; set; }
public TimeSpan Duration { get; set; }
    }
}