using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Controllers.BaseControllers;
using AppAgendamentos.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppAgendamentos.Controllers
{
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
***REMOVED******REMOVED***model.CompanyServices.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name + " - R$" + item.Price });
***REMOVED***    }

***REMOVED***    List<TimeSpan> availableTimes = this.GetAvailableTimes(company.Id, DateTime.Parse("2023-03-23"));

***REMOVED***    foreach (var item in availableTimes)
***REMOVED***    {
***REMOVED******REMOVED***model.AvailableTimeSlots.Add(new SelectListItem{ Value = item.ToString(), Text = TimeOnly.Parse(item.ToString()).ToString()});
***REMOVED***    }

***REMOVED***    return View(model);
***REMOVED***}

***REMOVED***private List<TimeSpan> GetAvailableTimes(int companyId, DateTime dateTime)
***REMOVED***{
***REMOVED***    DateTime date = dateTime.Date;

***REMOVED***    List<TimeSpan> list = _serviceScheduling.GetAvailableTimes(companyId, date);
***REMOVED***    return list;
***REMOVED***}
    }
}