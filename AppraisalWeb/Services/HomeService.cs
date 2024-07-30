using AppraisalBussiness.Interfaces;
using AppraisalWeb.ViewModel;
namespace AppraisalWeb.Services;

public class HomeService
{
    private IUserRepository _rpUser;
    public HomeService(IUserRepository rpUser)
    {
        _rpUser = rpUser;
    }

    public HomeVM GetProfile(string nik)
    {
        var model = _rpUser.get(Convert.ToInt32(nik));
        
        return new HomeVM()
        {
            Nik = model.Nik.ToString(),
            Name = model.Nama,
            Division = model.DivisiOrDepartemen,
            Jabatan = model.Jabatan
        };
    }
}
