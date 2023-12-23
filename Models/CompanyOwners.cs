using AppAgendamentos.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgendamentos.Models;
[Table("companies_owners")]
public class CompanyOwners : EntityBase
{
    public int CompanyId { get; set; }
    public Company Company { get; set; }
    public int UserId { get; set; }
    public ApplicationUser User { get; set; }
}