using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AppraisalWeb.ViewModel;
public class AuthLoginVM
{
    [Required]
    public string NIK { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string? Role { get; set; }
    public List<SelectListItem>? Roles { get; set; } = new List<SelectListItem>();
}

