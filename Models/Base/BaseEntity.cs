using System.ComponentModel.DataAnnotations;
using AppAgendamentos.Enums;

namespace AppAgendamentos.Models.Base;
public abstract class BaseEntity
{
    public int Id { get; set; }
    [Required]
    public StatusEnum? Status { get; set; }
    [Required]
    public DateTime RegisterDate { get; set; }
    [Required]
    public DateTime UpdateDate { get; set; }
}