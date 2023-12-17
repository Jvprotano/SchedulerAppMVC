using System.ComponentModel.DataAnnotations;
using AppAgendamentos.Enums;

namespace AppAgendamentos.Models.Base;
public abstract class EntityBase
{
    public int Id { get; set; }
    [Required]
    public StatusEnum? Status { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
}