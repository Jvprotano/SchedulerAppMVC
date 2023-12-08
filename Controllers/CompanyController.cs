using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AppAgendamentos.Controllers
{
    public class CompanyController : Controller
    {
***REMOVED***private readonly IService<Company> _companyService;

***REMOVED***public CompanyController(IService<Company> companyService)
***REMOVED***{
***REMOVED***    _companyService = companyService;
***REMOVED***}

***REMOVED***public IActionResult Index()
***REMOVED***{
***REMOVED***    return RedirectToAction("Create");
***REMOVED***}

***REMOVED***public IActionResult Create()
***REMOVED***{
***REMOVED***    var model = new CompanyViewModel();
***REMOVED***    return View(model);
***REMOVED***}

***REMOVED***[HttpPost]
***REMOVED***public async Task<IActionResult> Create(Company company)
***REMOVED***{
***REMOVED***    try
***REMOVED***    {
***REMOVED******REMOVED***await _companyService.SaveAsync(company);
***REMOVED******REMOVED***return RedirectToAction("Index", "Home");
***REMOVED***    }
***REMOVED***    catch(Exception ex)
***REMOVED***    {
***REMOVED******REMOVED***throw new Exception(ex.Message);
***REMOVED***    }
***REMOVED***}
    }
}