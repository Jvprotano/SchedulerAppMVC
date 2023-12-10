using Microsoft.AspNetCore.Mvc;

namespace AppAgendamentos.Controllers.BaseControllers;
public class BaseController : Controller
{
    private readonly ILogger<BaseController> _logger;

    public BaseController(ILogger<BaseController> logger)
    {
        _logger = logger;
    }
}