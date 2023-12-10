using AppAgendamentos.Models.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgendamentos.Models;
[Table("companies_services_offered")]
public class CompanyServiceOffered : BaseEntity
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