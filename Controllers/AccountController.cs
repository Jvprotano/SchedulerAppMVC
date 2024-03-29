using Scheduler.Contracts.Services;
using Scheduler.Controllers.BaseControllers;
using Scheduler.Models;
using Scheduler.ViewModels;

using AutoMapper;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Scheduler.Controllers;
[Route("[controller]/[action]")]
public class AccountController : BaseController
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ICompanyService _serviceCompany;
    private readonly IMapper _mappper;

    public AccountController(ILogger<BaseController> logger, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IMapper mappper, ICompanyService serviceCompany) : base(logger)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mappper = mappper;
        _serviceCompany = serviceCompany;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (await _userManager.FindByEmailAsync(model.Email) != null)
            ModelState.AddModelError(string.Empty, "Email already exists");
        if (model.Password != model.ConfirmPassword)
            ModelState.AddModelError(string.Empty, "Passwords don't match");

        if (ModelState.IsValid)
        {
            var user = _mappper.Map<ApplicationUser>(model);
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.EmailOrUserName);

            var result = await _signInManager.PasswordSignInAsync(user?.UserName ?? model.EmailOrUserName, model.Password, model.RememberMe, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt");
        }

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> MyCompanies()
    {
        var user = await _userManager.FindByNameAsync(User.Identity.Name);

        user.Companies = (await _serviceCompany.GetCompaniesByUserAsync(user.Id)).ToList();

        var model = _mappper.Map<AccountViewModel>(user);

        return View(model);
    }
}
