using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AppAgendamentos.Controllers.BaseControllers
{
    [Route("[controller]")]
    public class BaseController : Controller
    {
***REMOVED***private readonly ILogger<BaseController> _logger;

***REMOVED***public BaseController(ILogger<BaseController> logger)
***REMOVED***{
***REMOVED***    _logger = logger;
***REMOVED***}
    }
}