using AppraisalDataAccess.Models;
namespace AppraisalWeb.ViewModel;

public class HomeVM
{
    public string Nik { get; set; }
    public string Name { get; set; }
    public string Division { get; set; }
    public string Jabatan { get; set; }
    public bool IsEvaluated { get; set; }
}

