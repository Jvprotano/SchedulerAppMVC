using AppAgendamentos.Enums;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models;
public class CompanyCategory : BaseEntity
{
    public int CompanyId { get; set; }
    public CategoryEnum CategoryId { get; set; }
    public Company Company { get; set; }
}