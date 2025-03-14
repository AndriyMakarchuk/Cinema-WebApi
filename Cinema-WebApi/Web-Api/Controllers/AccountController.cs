using BusinessLogic.DTOs;
using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }
    public IActionResult Login()
    {
        return View();
    }
    [HttpGet]
    public IActionResult AccessDenied()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(UserLoginDTO model)
    {
        var user = _userService.Authenticate(model.Email, model.PasswordHash);
        if (user != null)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Surname, model.Email),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Surname, model.PasswordHash),
                new Claim(ClaimTypes.Role, user.Role ?? "User")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return RedirectToAction("Index", "Home");
        }

        ViewBag.Error = "Неправильний логін або пароль";
        return View();
    }

public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login");
    }

    [Authorize(Roles = "Admin")]
    public IActionResult AdminPage()
    {
        return View();
    }
    [Authorize]
    public IActionResult Profile()
    {
        return View();
    }
}

