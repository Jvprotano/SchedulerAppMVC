using AppAgendamentos.Contracts.Repositories;
using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Controllers.BaseControllers;
using AppAgendamentos.Enums;
using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppAgendamentos.Controllers;
[Route("[controller]/[action]")]
public class SchedulingController : BaseController
{
    private readonly ICompanyRepository _repositoryCompany;
    private readonly ISchedulingService _serviceScheduling;
    private readonly IMapper _mapper;

    public SchedulingController(ILogger<SchedulingController> logger, ICompanyRepository repositoryCompany,
     IMapper mapper, ISchedulingService serviceScheduling) : base(logger)
    {
        _repositoryCompany = repositoryCompany;
        _mapper = mapper;
        _serviceScheduling = serviceScheduling;
    }
    [HttpGet("{companyId}")]
    public async Task<IActionResult> Create(int companyId)
    {
        var company = await _repositoryCompany.GetByIdAsync(companyId);

        if (company == null)
        {
            ModelState.AddModelError("Company", "Company not found");
            return RedirectToAction("Index", "Home");
        }
        if (!company.ServicesOffered.Any())
        {
            ModelState.AddModelError("ServicesOffered", "Company has no services offered");
            return RedirectToAction("Index", "Home");
        }
        if (company.ScheduleStatus != ScheduleStatusEnum.Open)
        {
            ModelState.AddModelError("ScheduleStatus", "Company schedule is closed");
            return RedirectToAction("Index", "Home");
        }

        var model = _mapper.Map<SchedulingViewModel>(company);

        model.CompanyServices = company.ServicesOffered
            .Select(item => new SelectListItem
            {
                Value = item.Id.ToString(),
                Text = $"{item.Name} - {item.Price:C}"
            }).ToList();

        List<TimeSpan> availableTimes = (await _serviceScheduling.GetAvailableTimesAsync(company.Id, company.ServicesOffered.FirstOrDefault().Id, DateOnly.FromDateTime(DateTime.Now))).ToList();

        model.AvailableTimeSlots = availableTimes
            .Select(item => new SelectListItem
            {
                Value = item.ToString(),
                Text = TimeOnly.Parse(item.ToString()).ToString()
            }).ToList();

        return View(model);
    }
    [HttpPost]
    public async Task<ActionResult> Create(SchedulingViewModel model)
    {
        try
        {
            var scheduling = _mapper.Map<Scheduling>(model);
            await _serviceScheduling.SaveAsync(scheduling);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<JsonResult> GetAvailableTimes(int companyId, int serviceSelected, DateOnly dateSelected)
    {
        try
        {
            List<TimeSpan> listTimes = (await _serviceScheduling.GetAvailableTimesAsync(companyId, serviceSelected, dateSelected)).ToList();

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