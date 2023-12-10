using AppAgendamentos.Enums;
using AppAgendamentos.Models.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgendamentos.Models;
[Table("companies_categories")]
public class CompanyCategory : BaseEntity
{
    public int CompanyId { get; set; }
    public CategoryEnum CategoryId { get; set; }
    public Company Company { get; set; }
}