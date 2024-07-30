using AppraisalWeb.ViewModel;
namespace AppraisalWeb.ViewModel;
public class IndikatorUtamaVM
    {
        public string? Kpi { get; set; } 

        public string? UoM { get; set; } 

        public string? Polarisasi { get; set; } 

        public int Target { get; set; }

        public int Aktual { get; set; }

        public int TingkatUnjukKerja { get; set; }

        public int NilaiUnjukKerja { get; set; }

        public string? RekapId { get; set; } 
    }
