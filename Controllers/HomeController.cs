using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppAgendamentos.Models;

namespace AppAgendamentos.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
***REMOVED***_logger = logger;
    }

    public IActionResult Index()
    {
***REMOVED***return View();
    }

    public IActionResult Privacy()
    {
***REMOVED***return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
***REMOVED***return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
