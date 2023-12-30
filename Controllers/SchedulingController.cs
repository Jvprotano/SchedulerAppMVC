using AutoMapper;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Scheduler.Contracts.Services;
using Scheduler.Controllers.BaseControllers;
using Scheduler.Enums;
using Scheduler.Models;
using Scheduler.ViewModels;

namespace Scheduler.Controllers;
[Route("[controller]/[action]")]
public class SchedulingController : BaseController
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ICompanyService _companyService;
    private readonly ISchedulingService _serviceScheduling;
    private readonly IMapper _mapper;

    public SchedulingController(ILogger<SchedulingController> logger, ICompanyService companyService,
     IMapper mapper, ISchedulingService serviceScheduling, UserManager<ApplicationUser> userManager) : base(logger)
    {
        _companyService = companyService;
        _mapper = mapper;
        _serviceScheduling = serviceScheduling;
        _userManager = userManager;
    }
    [HttpGet("{companyId}")]
    public async Task<IActionResult> Create(int companyId)
    {
        var company = await _companyService.GetByIdAsync(companyId);

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
            if (String.IsNullOrWhiteSpace(model.TimeSelected))
                throw new Exception("Time is required");
            if (String.IsNullOrWhiteSpace(model.ServiceSelected))
                throw new Exception("Service is required");
            if (model.ScheduledDate == default)
                throw new Exception("Date is required");

            var scheduling = _mapper.Map<Scheduling>(model);

            if (User.Identities.Any(c => c.IsAuthenticated))
            {
                var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
                scheduling.CustomerId = user.Id;
            }
            else
            {
                var newUser = new ApplicationUser
                {
                    UserName = model.CustomerName,
                    Email = model.CustomerName,
                    PhoneNumber = model.Phone
                };
                await _userManager.CreateAsync(newUser);
            }
            await _serviceScheduling.SaveAsync(scheduling);
            SetMessageSuccess("Scheduling created successfully!");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(model);
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