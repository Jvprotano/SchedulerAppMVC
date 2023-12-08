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
    private readonly IService<Company> _companyService;
    private readonly IService<ServicesOffered> _serviceOfferedService;
    private readonly IMapper _mapper;

    public CompanyController(ILogger<BaseController> logger, IService<Company> companyService, 
    IService<ServicesOffered> serviceOfferedService, IMapper mapper) : base(logger)
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
            ServicesOffereds = (await _serviceOfferedService.GetAllAsync()).ToList()
            .Select(s => new SelectListItem(text: s.Name, value: s.Id.ToString())).ToList()
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
            return RedirectToAction("Index", "Home");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}