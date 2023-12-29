using Microsoft.AspNetCore.Mvc;

namespace Scheduler.Controllers.BaseControllers;
public class BaseController : Controller
{
    private readonly ILogger<BaseController> _logger;

    public BaseController(ILogger<BaseController> logger)
    {
        _logger = logger;
    }
    protected void SetMessageSuccess(string message)
    {
        TempData["SuccessMessage"] = message;
    }
}