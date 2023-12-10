using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Controllers.BaseControllers;
using AppAgendamentos.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace AppAgendamentos.Controllers;

public class HomeController : BaseController
{
    private readonly ICompanyRepository _companyRepository;

    public HomeController(ILogger<BaseController> logger, ICompanyRepository companyRepository) : base(logger)
    {
        _companyRepository = companyRepository;
    }

    public async Task<IActionResult> Index()
    {
        HomeViewModel model = new HomeViewModel()
        {
            Companies = (await _companyRepository.GetAllAsync()).ToList()
        };

        return View(model);
    }
}
