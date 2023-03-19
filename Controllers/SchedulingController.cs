using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppAgendamentos.Controllers
{
    // [Route("[controller]")]
    public class SchedulingController : Controller
    {
***REMOVED***private readonly ILogger<SchedulingController> _logger;
***REMOVED***private readonly ICompanyRepository _repositoryCompany;
***REMOVED***private readonly IMapper _mapper;

***REMOVED***public SchedulingController(ILogger<SchedulingController> logger, ICompanyRepository repositoryCompany, IMapper mapper)
***REMOVED***{
***REMOVED***    _logger = logger;
***REMOVED***    _repositoryCompany = repositoryCompany;
***REMOVED***    _mapper = mapper;
***REMOVED***}

***REMOVED***public async Task<IActionResult> Create(int companyId)
***REMOVED***{
***REMOVED***    var empresa = await _repositoryCompany.GetAsync(companyId);

***REMOVED***    SchedulingViewModel model = _mapper.Map<SchedulingViewModel>(empresa);

***REMOVED***    foreach (var item in empresa.ServicesOffered){
***REMOVED******REMOVED***model.CompanyServices.Add(new SelectListItem { Value = item.Id.ToString(), Text = item.Name + " - R$" + item.Price});
***REMOVED***    }

***REMOVED***    return View(model);
***REMOVED***}
    }
}