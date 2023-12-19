using AppAgendamentos.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgendamentos.Models;
[Table("schedulings")]
public class Scheduling : EntityBase
{
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int CustomerId { get; set; }
    public User Customer { get; set; }
    public DateTime ScheduledDate { get; set; }
    public int ServicesOfferedId { get; set; }
    public CompanyServiceOffered ServiceOffered { get; set; }
}