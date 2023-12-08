using System.ComponentModel.DataAnnotations;

namespace AppAgendamentos.Models.Base;
public abstract class Profile : BaseEntity
{           
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    public int? CityId { get; set; }
    public City City { get; set; }
    public string Address { get; set; }
    public string AddressNumber { get; set; }
    public string PostalCode { get; set; }
    public string ImageUrl { get; set; }
}