using AppraisalWeb.ViewModel;
namespace AppraisalWeb.ViewModel;
public class IndikatorAreaVM
{
    public string? Aspek { get; set; } 

    public string? Keterangan { get; set; } 

    public int Target { get; set; }

    public int Aktual { get; set; }

    public int TingkatUnjukKerja { get; set; }

    public int NilaiUnjukKerja { get; set; }

    public string? RekapId { get; set; } 
}

