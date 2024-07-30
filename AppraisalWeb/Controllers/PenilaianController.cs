using AppraisalBussiness.Interfaces;
using AppraisalWeb.Services;
using AppraisalWeb.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static AppraisalWeb.Constant;
namespace AppraisalWeb.Controllers;

public class PenilaianController:Controller
{
    private readonly PenilaianService _penilaianService;

    public PenilaianController(PenilaianService penilaianService)
    {
        _penilaianService = penilaianService;
    }

    [HttpGet("PenilaianIndex")]
    public IActionResult PenilaianIndex(int page =  PAGE, int pageSize = PAGE_SIZE)
    {

        var jabatan = HttpContext.User.FindFirst(ClaimTypes.Role);
        ViewBag.Role = jabatan.Value;
        PenilaianIndexVM viewModel = _penilaianService.getAll(page, pageSize);
        return View("PenilaianIndex", viewModel);
    }
    [HttpGet("FormPenilaian/{nik}")]
    public IActionResult FormPenilaian(int nik)
    {
        var jabatan = HttpContext.User.FindFirst(ClaimTypes.Role);
        ViewBag.Role = jabatan.Value;
        FormPenilaianVM formPenilaianVM = _penilaianService.GenerateFormPenilaian(nik);

        return View("FormPenilaian", formPenilaianVM);
    }

    [HttpPost("FormPenilaian")]
    public IActionResult FormPenilaian(FormPenilaianVM penilaianVM)
    {
        var jabatan = HttpContext.User.FindFirst(ClaimTypes.Role);
        var nikPenilai = HttpContext.User.FindFirst("nik");
        ViewBag.Role = jabatan.Value;
        _penilaianService.BuatPenilaian(penilaianVM, Convert.ToInt32(nikPenilai.Value));
        return RedirectToAction("PenilaianIndex");
    }
}
