using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Controllers.BaseControllers;
using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppAgendamentos.Controllers
{
    [Route("[controller]")]
    public class SchedulingController : BaseController
    {
private readonly ICompanyRepository _repositoryCompany;
private readonly ISchedulingRepository _repositoryScheduling;
private readonly ISchedulingService _serviceScheduling;
private readonly IMapper _mapper;

public SchedulingController(ILogger<SchedulingController> logger, ICompanyRepository repositoryCompany, IMapper mapper, ISchedulingRepository repositoryScheduling, ISchedulingService serviceScheduling) : base(logger)
{
    _repositoryCompany = repositoryCompany;
    _mapper = mapper;
    _repositoryScheduling = repositoryScheduling;
    _serviceScheduling = serviceScheduling;
}

public async Task<IActionResult> Create(int companyId)
{
    var company = await _repositoryCompany.GetAsync(companyId);

    SchedulingViewModel model = _mapper.Map<SchedulingViewModel>(company);

    foreach (var item in company.ServicesOffered)
    {
model.CompanyServices.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name + " - " + string.Format("{0:C}", item.Price) });
    }

    List<TimeSpan> availableTimes = _serviceScheduling.GetAvailableTimes(company.Id, company.ServicesOffered.FirstOrDefault().Id, DateOnly.FromDateTime(DateTime.Now));

    foreach (var item in availableTimes)
    {
model.AvailableTimeSlots.Add(new SelectListItem { Value = item.ToString(), Text = TimeOnly.Parse(item.ToString()).ToString() });
    }

    return View(model);
}
[HttpPost]
public ActionResult Create(SchedulingViewModel model)
{
    try
    {
var scheduling = _mapper.Map<Scheduling>(model);
// _serviceScheduling.Save(scheduling);
    }
    catch (Exception ex)
    {
throw new Exception(ex.Message);
    }

    return RedirectToAction("Index", "Home");
}

[HttpPost]
[Route("GetAvailableTimesJson")]
public JsonResult GetAvailableTimes(int companyId, int serviceSelected, DateOnly dateSelected)
{
    try
    {
List<TimeSpan> listTimes = _serviceScheduling.GetAvailableTimes(companyId, serviceSelected, dateSelected);

Response.StatusCode = 200;
return Json(listTimes);
    }
    catch (Exception ex)
    {
Response.StatusCode = 500;
return Json(ex.Message);
    }

}
    }
}