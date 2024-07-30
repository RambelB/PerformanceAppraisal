using Microsoft.AspNetCore.Mvc;
using AppraisalWeb.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using AppraisalWeb.ViewModel;
using AppraisalWeb.ViewModel.Auth;

namespace AppraisalWeb.Controllers;
public class AuthController : Controller
{
    private readonly AuthService _authService;
    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Login");
    }
    [HttpGet("Login")]
    public IActionResult Login()
    {
        if (User?.Identity?.IsAuthenticated ?? false)
        {
            return RedirectToAction("Index", "Home");
        }
        var viewModel = _authService.GetLoginRoles();
        return View("LoginForm", viewModel);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(AuthLoginVM viewModel)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var ticket = _authService.SetLogin(viewModel);
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, ticket.Principal,
                    ticket.Properties);
                return RedirectToAction("Index", "Home");
            }
            catch (System.Exception exceptions)
            {
                ViewBag.Message = exceptions.Message;
            }
        }
        var roles = _authService.GetLoginRoles();
        return View("LoginForm", roles);
    }

    [HttpGet("AccessDenied")]
    public IActionResult AccessDenied()
    {
        return View("AccessDenied");
    }

    [HttpGet("Register")]
    public IActionResult Register(string role)
    {
        if (User?.Identity?.IsAuthenticated ?? false)
            return RedirectToAction("HomeIndex", "Home");

        ViewBag.Role = role;
        return View("RegisterForm");
    }

    [HttpPost("RegisterGuest")]
    public IActionResult RegisterGuest(AuthRegisterVM viewModel)
    {
        if (ModelState.IsValid)
        {
            _authService.AddRegisterGuest(viewModel);
            return RedirectToAction("Login");
        }
        ViewBag.Role = viewModel.Jabatan;
        return View("RegisterForm");
    }
}
