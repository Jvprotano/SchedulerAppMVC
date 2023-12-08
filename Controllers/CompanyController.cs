using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppAgendamentos.Controllers
{
    public class CompanyController : Controller
    {
private readonly IService<Company> _companyService;

public CompanyController(IService<Company> companyService)
{
    _companyService = companyService;
}

public IActionResult Index()
{
    return RedirectToAction("Create");
}

public IActionResult Create()
{
    var model = new CompanyViewModel();
    return View(model);
}

[HttpPost]
public async Task<IActionResult> Create(Company company)
{
    try
    {
await _companyService.SaveAsync(company);
return RedirectToAction("Index", "Home");
    }
    catch(Exception ex)
    {
throw new Exception(ex.Message);
    }
}
    }
}