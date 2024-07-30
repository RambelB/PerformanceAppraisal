using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AppraisalWeb.Controllers;

public class AccountController : Controller
{
    [HttpGet("Logout")]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Auth");
    }
    //[HttpGet("ChangePassword")]
    //public async Task<IActionResult> ChangePassword()
    //{

    //    return RedirectToAction("ChangePassword", "Auth");
    //}
}
