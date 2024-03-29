using Scheduler.Models.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler.Models;
[Table("companies_services_offered")]
public class CompanyServiceOffered : EntityBase
{
    [Required]
    public string Name { get; set; }
    [Required]
    public float Price { get; set; }
    [Required]
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public TimeSpan Duration { get; set; }

    public IList<Scheduling> Schedulings { get; set; }
}