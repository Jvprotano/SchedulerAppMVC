using Scheduler.Enums;
using Scheduler.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler.Models;
[Table("companies_categories")]
public class CompanyCategory : EntityBase
{
    public int CompanyId { get; set; }
    public CategoryEnum CategoryId { get; set; }
    public Company Company { get; set; }
}