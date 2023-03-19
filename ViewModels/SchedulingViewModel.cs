using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppAgendamentos.ViewModels
{
    public class SchedulingViewModel
    {
***REMOVED***public int CompanyId { get; set; }
***REMOVED***public string CompanyName { get; set; }
***REMOVED***public string CompanyDescription { get; set; }
***REMOVED***public string CompanyImage { get; set; }

***REMOVED***public int CustomerId { get; set; }


***REMOVED***public SelectListItem ServiceSelected { get; set; }

***REMOVED***public IList<SelectListItem> CompanyServices { get; set; }

***REMOVED***public DateTime ScheduledDate { get; set; }


***REMOVED***public SchedulingViewModel()
***REMOVED***{
***REMOVED***    CompanyServices = new List<SelectListItem>();
***REMOVED***    ScheduledDate = DateTime.Now;
***REMOVED***}
    }
}