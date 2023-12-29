using Scheduler.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace Scheduler.Models;
[Table("companies_owners")]
public class CompanyOwners : EntityBase
{
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int UserId { get; set; }
    public ApplicationUser User { get; set; }
}