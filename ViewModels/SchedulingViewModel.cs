using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppAgendamentos.ViewModels;
public class SchedulingViewModel
{
    public int CompanyId { get; set; }
    public string CompanyName { get; set; }
    public string CompanyDescription { get; set; }
    public string CompanyImage { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; }
    public string Phone { get; set; }
    public string ConfirmationCode { get; set; }

    public SelectListItem ServiceSelected { get; set; }
    public IList<SelectListItem> CompanyServices { get; set; }
    public IList<SelectListItem> AvailableTimeSlots { get; set; }
    public DateTime ScheduledDate { get; set; }
    public TimeSpan ScheduledTime { get; set; }
    public SelectListItem TimeSelected { get; set; }


    public SchedulingViewModel()
    {
        CompanyServices = new List<SelectListItem>();
        ScheduledDate = DateTime.Now;
        AvailableTimeSlots = new List<SelectListItem>();
    }
}