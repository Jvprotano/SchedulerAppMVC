using System.ComponentModel.DataAnnotations.Schema;
using Scheduler.Models.Base;

namespace Scheduler.Models;
[Table("cities")]
public class City : EntityBase
{
    public string Name { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
}