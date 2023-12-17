using AppAgendamentos.Models.Base;

using AutoMapper.Configuration.Annotations;

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
    public IList<CompanyCategory> Categories { get; set; } = new List<CompanyCategory>();
    public IList<CompanyServiceOffered> ServicesOffered { get; set; } = new List<CompanyServiceOffered>();

    public List<int> SelectedCategoryIds { get; set; }
    public List<string> SelectedServicesNames { get; set; }
}