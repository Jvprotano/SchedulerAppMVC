using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    [Table("schedulings")]
    public class Scheduling : BaseEntity
    {
public int CompanyId { get; set; }
public Company Company { get; set; }
public int CustomerId { get; set; }
public User Customer { get; set; }
public DateTime ScheduledDate { get; set; }

public int ServicesOfferedId { get; set; }
public ServicesOffered ServicesOffered { get; set; }
    }
}