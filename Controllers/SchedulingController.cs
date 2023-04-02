using AppAgendamentos.Contracts.Repository;
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
***REMOVED***private readonly ICompanyRepository _repositoryCompany;
***REMOVED***private readonly ISchedulingRepository _repositoryScheduling;
***REMOVED***private readonly ISchedulingService _serviceScheduling;
***REMOVED***private readonly IMapper _mapper;

***REMOVED***public SchedulingController(ILogger<SchedulingController> logger, ICompanyRepository repositoryCompany, IMapper mapper, ISchedulingRepository repositoryScheduling, ISchedulingService serviceScheduling) : base(logger)
***REMOVED***{
***REMOVED***    _repositoryCompany = repositoryCompany;
***REMOVED***    _mapper = mapper;
***REMOVED***    _repositoryScheduling = repositoryScheduling;
***REMOVED***    _serviceScheduling = serviceScheduling;
***REMOVED***}

***REMOVED***public async Task<IActionResult> Create(int companyId)
***REMOVED***{
***REMOVED***    var company = await _repositoryCompany.GetAsync(companyId);

***REMOVED***    SchedulingViewModel model = _mapper.Map<SchedulingViewModel>(company);

***REMOVED***    foreach (var item in company.ServicesOffered)
***REMOVED***    {
***REMOVED******REMOVED***model.CompanyServices.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name + " - " + string.Format("{0:C}", item.Price) });
***REMOVED***    }

***REMOVED***    List<TimeSpan> availableTimes = _serviceScheduling.GetAvailableTimes(company.Id, company.ServicesOffered.FirstOrDefault().Id, DateOnly.FromDateTime(DateTime.Now));

***REMOVED***    foreach (var item in availableTimes)
***REMOVED***    {
***REMOVED******REMOVED***model.AvailableTimeSlots.Add(new SelectListItem { Value = item.ToString(), Text = TimeOnly.Parse(item.ToString()).ToString() });
***REMOVED***    }

***REMOVED***    return View(model);
***REMOVED***}
***REMOVED***[HttpPost]
***REMOVED***public ActionResult Create(SchedulingViewModel model)
***REMOVED***{
***REMOVED***    try
***REMOVED***    {
***REMOVED******REMOVED***var scheduling = _mapper.Map<Scheduling>(model);
***REMOVED******REMOVED***// _serviceScheduling.Save(scheduling);
***REMOVED***    }
***REMOVED***    catch (Exception ex)
***REMOVED***    {
***REMOVED******REMOVED***throw new Exception(ex.Message);
***REMOVED***    }

***REMOVED***    return RedirectToAction("Index", "Home");
***REMOVED***}

***REMOVED***[HttpPost]
***REMOVED***[Route("GetAvailableTimesJson")]
***REMOVED***public JsonResult GetAvailableTimes(int companyId, int serviceSelected, DateOnly dateSelected)
***REMOVED***{
***REMOVED***    try
***REMOVED***    {
***REMOVED******REMOVED***List<TimeSpan> listTimes = _serviceScheduling.GetAvailableTimes(companyId, serviceSelected, dateSelected);

***REMOVED******REMOVED***Response.StatusCode = 200;
***REMOVED******REMOVED***return Json(listTimes);
***REMOVED***    }
***REMOVED***    catch (Exception ex)
***REMOVED***    {
***REMOVED******REMOVED***Response.StatusCode = 500;
***REMOVED******REMOVED***return Json(ex.Message);
***REMOVED***    }

***REMOVED***}
    }
}