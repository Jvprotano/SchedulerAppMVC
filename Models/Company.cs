using AppAgendamentos.Models.Base;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgendamentos.Models;
[Table("companies")]
public class Company : ProfileBase
{
    [Required]
    public string Description { get; set; }
    public string Cnpj { get; set; }
    public bool IsVirtual { get; set; }
    public IList<CompanyOwners> Owners;
    public IList<CompanyCategory> Categories { get; set; }
    public IList<CompanyServiceOffered> ServicesOffered { get; set; }
    public IList<CompanyOpeningHours> OpeningHours { get; set; }

    public List<int> SelectedCategoryIds { get; set; }
    public List<string> SelectedServicesNames { get; set; }
}