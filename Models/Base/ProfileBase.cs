using System.ComponentModel.DataAnnotations;

namespace Scheduler.Models.Base;
public abstract class ProfileBase : EntityBase
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
    public bool AutoGeneratedImage { get; set; }
    public string ImagePrompt { get; set; }
    public string ImageBase64 { get; set; }

    public IList<Scheduling> Schedulings { get; set; }
}