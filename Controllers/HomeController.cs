using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Models.Base;
using AppAgendamentos.ViewModels;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace AppAgendamentos.Controllers;

public class HomeController : Controller
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, ICompanyRepository companyRepository)
    {
***REMOVED***_logger = logger;
***REMOVED***_companyRepository = companyRepository;
    }

    public async Task<IActionResult> Index()
    {
***REMOVED***HomeViewModel model = new HomeViewModel();

***REMOVED***model.Companies = await _companyRepository.GetAllAsync();

***REMOVED***return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
***REMOVED***return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
