using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    public class CompanyOwners : BaseEntity
    {
public int CompanyId { get; set; }
public Company Company { get; set; }
public int UserId { get; set; }
public User User { get; set; }
    }
}