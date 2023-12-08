using AppAgendamentos.Models.Base;
using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppAgendamentos.Models;
[Table("companies")]
public class Company : Profile
{
    [Required]
    public string Description { get; set; }
    public string Cnpj { get; set; }
    public bool IsVirtual { get; set; }
    public IList<CompanyOwners> Owners;
    public IList<CompanyCategory> Categories;
    public IList<ServicesOffered> ServicesOffered;

    public List<int> CategoryIds { get; set; }
    public List<int> ServicesOfferedIds { get; set; }
}