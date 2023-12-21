using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Controllers.BaseControllers;
using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace AppAgendamentos.Controllers;
public class UserController : BaseController
{
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(ILogger<BaseController> logger, IMapper mapper, IUserService userService) : base(logger)
    {
        _mapper = mapper;
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }
    [HttpGet]
    public IActionResult Create()
    {
        var model = new UserViewModel();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(UserViewModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var user = _mapper.Map<User>(model);

                await _userService.SaveAsync(user);

                SetMessageSuccess("User saved successfully");
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
        }
        return View(model);
    }
}