using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using AppraisalWeb.Services;
using AppraisalWeb.ViewModel;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace AppraisalWeb.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly HomeService _service;

        public HomeController(HomeService service)
        {
            _service = service;
        }
        [HttpGet("HomeIndex")]
        public IActionResult Index()
        {
            var nik = HttpContext.User.FindFirst("nik");
            var jabatan = HttpContext.User.FindFirst(ClaimTypes.Role);
            ViewBag.Role = jabatan.Value;
            if(nik != null){
            HomeVM vm = _service.GetProfile(nik.Value);
                return View("Home", vm);
            }
            else { return View("Index", "Auth"); }
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
