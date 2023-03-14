using AppAgendamentos.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppAgendamentos.Controllers
{
    // [Route("[controller]")]
    public class SchedulingController : Controller
    {
***REMOVED***private readonly ILogger<SchedulingController> _logger;

***REMOVED***public SchedulingController(ILogger<SchedulingController> logger)
***REMOVED***{
***REMOVED***    _logger = logger;
***REMOVED***}

***REMOVED***public IActionResult Create()
***REMOVED***{
***REMOVED***    SchedulingViewModel model = new SchedulingViewModel();

***REMOVED***    return View(model);
***REMOVED***}
    }
}