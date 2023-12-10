using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Controllers.BaseControllers;
using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppAgendamentos.Controllers;
public class CompanyController : BaseController
{
    private readonly ICompanyService _companyService;
    private readonly IService<CompanyServiceOffered> _serviceOfferedService;
    private readonly IMapper _mapper;

    public CompanyController(ILogger<BaseController> logger, ICompanyService companyService,
    IService<CompanyServiceOffered> serviceOfferedService, IMapper mapper) : base(logger)
    {
        _companyService = companyService;
        _serviceOfferedService = serviceOfferedService;
        _mapper = mapper;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Create");
    }

    public async Task<IActionResult> Create()
    {
        var model = new CompanyViewModel()
        {
            ServicesOfferedsSelect = (await _serviceOfferedService.GetAllAsync()).ToList()
            .Select(s => new SelectListItem(text: s.Name, value: s.Name.ToString())).ToList()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CompanyViewModel model)
    {
        try
        {
            var company = _mapper.Map<Company>(model);
            await _companyService.SaveAsync(company);
            SetMessageSuccess("Company saved successfully");
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError(string.Empty, ex.Message);
            return RedirectToAction("Create", model);
        }
    }
    private void SetMessageSuccess(string message)
    {
        TempData["SuccessMessage"] = message;
    }
}