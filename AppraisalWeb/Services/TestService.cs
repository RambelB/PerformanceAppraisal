using AppraisalBussiness.Interfaces;
using AppraisalWeb.ViewModel;
namespace AppraisalWeb.Services
{
    public class TestService
    {
        private readonly IUserRepository _rpUser;

        public TestService(IUserRepository rpUser)
        {
            _rpUser = rpUser;
        }
        //public TestIndexVM Get()
        //{
        //    var models = _rpUser.getAll();
        //    var usernames = models.Select(x => new TestVM()
        //    {
        //        usersName = x.Nama,
        //        jabatan = x.Jabatan
        //    }).ToList();
        //    return new TestIndexVM()
        //    {
        //       testVMs = usernames
        //    };
        //}
    }
}
