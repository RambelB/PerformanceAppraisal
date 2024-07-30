using AppraisalWeb.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace AppraisalWeb.ViewModel;
public class FormPenilaianVM
{
    public int nik { get; set; }
    public string? name { get; set; }
    public string? jabatan { get; set; }
    public string? divisi { get; set; }
    public List<SelectListItem>? kpi = new List<SelectListItem>();
    public List<SelectListItem>? unitOfMeasurement = new List<SelectListItem>();
    public List<SelectListItem>? polarisasi = new List<SelectListItem>();
    public List<IndikatorUtamaVM>? IndikatorUtama { get; set; }
    public KompentensiDasarVM? KompetensiDasar { get; set; }
    public List<IndikatorAreaVM>? IndikatorArea { get; set; }
    public PerubahanNilaiVM? PerubahanNilai { get; set; }
}
