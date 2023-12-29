using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Controllers.BaseControllers;
using AppAgendamentos.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace AppAgendamentos.Controllers;

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
