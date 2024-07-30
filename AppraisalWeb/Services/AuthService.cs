using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using AppraisalBussiness.Interfaces;
using AppraisalBussiness.Repositories;
using AppraisalDataAccess.Models;
using AppraisalWeb.ViewModel;
using AppraisalWeb.ViewModel.Auth;

namespace AppraisalWeb.Services;
public class AuthService
{
    private readonly IUserRepository _repositoryUser;
    public AuthService(IUserRepository repositoryUser)
    {
        _repositoryUser = repositoryUser;
    }
    private ClaimsPrincipal GetPrincipal(AuthLoginVM viewModel)
    {// jadi async task<claimsprincipal>
        var claims = new List<Claim>(){
            new Claim("nik", viewModel.NIK),
            new Claim(ClaimTypes.Role, viewModel.Role??string.Empty)
        };
        ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        return new ClaimsPrincipal(identity);
    }

    private AuthenticationTicket GetTicket(ClaimsPrincipal principal)
    {
        AuthenticationProperties authenticationProperties = new AuthenticationProperties()
        {
            IssuedUtc = DateTime.Now,
            ExpiresUtc = DateTime.Now.AddMinutes(30),
            AllowRefresh = false
        };
        AuthenticationTicket authenticationTicket = new AuthenticationTicket(
            principal, authenticationProperties, CookieAuthenticationDefaults.AuthenticationScheme);

        return authenticationTicket;
    }

    public AuthenticationTicket SetLogin(AuthLoginVM viewModel)
    {
        User user = _repositoryUser.get(Convert.ToInt32(viewModel.NIK));
        if (user != null)
        {
            bool IsCorrectPassword = BCrypt.Net.BCrypt.Verify(viewModel.Password, user.Password.Trim());
            bool IsCorrectRole = user.Jabatan == viewModel.Role;
            if (!IsCorrectPassword || !IsCorrectRole)
                throw new Exception("Username, Password or Role is incorrect");

            var newModel = new AuthLoginVM()
            {
                NIK = user.Nik.ToString(),
                Password = user.Password,
                Role = viewModel.Role
            };

            ClaimsPrincipal principal = GetPrincipal(newModel);
            AuthenticationTicket ticket = GetTicket(principal);
            return ticket;
        }
        else
        {
            throw new Exception("Username, Password or Role is incorrect");
        }
    }

    private List<SelectListItem> GetRoles()
    {
        return new List<SelectListItem>(){
            new SelectListItem(){
                Text = "Penilai",
                Value = "Penilai"
            },
            new SelectListItem(){
                Text = "Karyawan",
                Value = "Karyawan"
            }
        };
    }

    public AuthLoginVM GetLoginRoles()
    {
        return new AuthLoginVM()
        {
            Roles = GetRoles(),
        };
    }

    public void AddRegisterGuest(AuthRegisterVM viewModel)
    {
        var user = new User()
        {
            Nik = viewModel.NIK,
            Password = BCrypt.Net.BCrypt.HashPassword(viewModel.Password),
            Nama = viewModel.FullName,
            DivisiOrDepartemen = viewModel.Divisi,
            Jabatan = viewModel.Jabatan,
            CreatedAt= DateTime.Now,
        };
        try
        {
            _repositoryUser.insert(user);
        }
        catch (System.Exception exceptions)
        {
            throw exceptions.InnerException;
        }
    }
}
