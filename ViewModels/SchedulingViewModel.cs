using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppAgendamentos.ViewModels
{
    public class SchedulingViewModel
    {
***REMOVED***public int CompanyId { get; set; }
***REMOVED***public string CompanyName { get; set; }

***REMOVED***public int CustomerId { get; set; }

***REMOVED***public IEnumerable<SelectListItem>? ListaTeste { get; set; }

***REMOVED***public DateTime ScheduledDate { get; set; }


***REMOVED***public SchedulingViewModel()
***REMOVED***{
***REMOVED***    CompanyName = String.Empty;
***REMOVED***    ListaTeste = new List<SelectListItem>();
***REMOVED***}
    }
}