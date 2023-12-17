using AppAgendamentos.Contracts.Services;
using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

namespace AppAgendamentos.Controllers;
[Route("[controller]")]
public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IMapper mapper, IUserService userService)
    {
        _logger = logger;
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
                User user = _mapper.Map<User>(model);

                await _userService.SaveAsync(user);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
        }
        return View(model);
    }
}