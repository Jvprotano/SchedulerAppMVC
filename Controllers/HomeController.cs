using Scheduler.Contracts.Repositories;
using Scheduler.Contracts.Services;
using Scheduler.Controllers.BaseControllers;
using Scheduler.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace Scheduler.Controllers;

public class HomeController : BaseController
{
    private readonly ICompanyService _companyService;

    public HomeController(ILogger<BaseController> logger, ICompanyService companyServiceICompanyService) : base(logger)
    {
        _companyService = companyServiceICompanyService;
    }

    public async Task<IActionResult> Index()
    {
        var model = new HomeViewModel()
        {
            Companies = (await _companyService.GetAllOpen()).ToList()
        };

        return View(model);
    }
}
