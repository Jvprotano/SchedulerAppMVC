using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppAgendamentos.Controllers
{
    // [Route("[controller]")]
    public class CompanyController : Controller
    {
***REMOVED***private readonly ICompanyRepository _companyRepository;
***REMOVED***private readonly ILogger<CompanyController> _logger;

***REMOVED***public CompanyController(ILogger<CompanyController> logger, ICompanyRepository companyRepository)
***REMOVED***{
***REMOVED***    _logger = logger;
***REMOVED***    _companyRepository = companyRepository;
***REMOVED***}

***REMOVED***public IActionResult Index()
***REMOVED***{
***REMOVED***    return RedirectToAction("Create");
***REMOVED***}

***REMOVED***public IActionResult Create()
***REMOVED***{
***REMOVED***    return View();
***REMOVED***}

***REMOVED***[HttpPost]
***REMOVED***public async Task<IActionResult> Create(Company company)
***REMOVED***{
***REMOVED***    await _companyRepository.SaveAsync(company);

***REMOVED***    return RedirectToAction("Index", "Home");
***REMOVED***}

***REMOVED***[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
***REMOVED***public IActionResult Error()
***REMOVED***{
***REMOVED***    return View("Error!");
***REMOVED***}
    }
}