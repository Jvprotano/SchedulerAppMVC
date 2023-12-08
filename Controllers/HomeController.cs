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
_logger = logger;
_companyRepository = companyRepository;
    }

    public async Task<IActionResult> Index()
    {
HomeViewModel model = new HomeViewModel();

model.Companies = await _companyRepository.GetAllAsync();

return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
