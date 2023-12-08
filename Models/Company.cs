using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AppAgendamentos.Models.Base;

namespace AppAgendamentos.Models
{
    [Table("companies")]
    public class Company : BaseEntity
    {
[Required]
public string Name { get; set; }
[Required]
public string Description { get; set; }
public string CNPJ { get; set; }
public string Image { get; set; }

public IList<CompanyOwners> Owners;
public IList<Category> Categories;
public IList<ServicesOffered> ServicesOffered;
    }
}