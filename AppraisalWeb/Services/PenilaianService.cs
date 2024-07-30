using AppraisalBussiness.Interfaces;
using AppraisalDataAccess.Models;
using AppraisalWeb.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppraisalWeb.Services;

public class PenilaianService
{
    private readonly IUserRepository _userRepository;
    private readonly IRekapitulasiRepository _rekapitulasiRepository;
    private readonly IIndikatorUtamaRepository _indikatorUtamaRepository;
    private readonly IIndikatorAreaRepository _indikatorAreaRepository;
    private readonly IKompetensiDasarRepository _kompetensiDasarRepository;
    private readonly IPerubahanNilaiRepository _perubahanNilaiRepository;
    private readonly IKpiRepository _kpiRepository;

    public PenilaianService(IUserRepository userRepository, IRekapitulasiRepository rekapitulasiRepository, IIndikatorUtamaRepository indikatorUtamaRepository, IIndikatorAreaRepository indikatorAreaRepository, IKompetensiDasarRepository kompetensiDasarRepository, IPerubahanNilaiRepository perubahanNilaiRepository, IKpiRepository kpiRepository)
    {
        _userRepository = userRepository;
        _rekapitulasiRepository = rekapitulasiRepository;
        _indikatorUtamaRepository = indikatorUtamaRepository;
        _indikatorAreaRepository = indikatorAreaRepository;
        _kompetensiDasarRepository = kompetensiDasarRepository;
        _perubahanNilaiRepository = perubahanNilaiRepository;
        _kpiRepository = kpiRepository;
    }

    public PenilaianIndexVM getAll(int page, int pageSize)
    {
        var models = _userRepository.getAll(page, pageSize);
        var employees= models.Select(x => new HomeVM()
        {
            Name = x.Nama,
            Division = x.DivisiOrDepartemen,
            IsEvaluated = _userRepository.isEvaluated(x.Nik)
        }).ToList();
        return new PenilaianIndexVM()
        {
            employees = employees,
            pagination = new PaginationVM()
            {
                Page = page,
                PageSize = pageSize,
                TotalRows = _userRepository.count()
            }
        };
    }
    private List<SelectListItem> GetKpi()
    {
        List<Kpi> kpiList = _kpiRepository.GetAll();
        List<SelectListItem> kpiSelectList = kpiList
            .Select(x => new SelectListItem
            {
                Text = x.Nama,
                Value = x.Nama
            })
            .ToList();

        return kpiSelectList;
    }

    private List<SelectListItem> GetUoM()
    {
        return new List<SelectListItem>(){
            new SelectListItem(){
                Text = "PROJEK",
                Value = "PROJEK"
            },
            new SelectListItem(){
                Text = "REPORT",
                Value = "REPORT"
            },
            new SelectListItem(){
                Text = "UNIT",
                Value = "UNIT"
            }
        };
    }

    private List<SelectListItem> GetPolarisasi()
    {
        return new List<SelectListItem>(){
            new SelectListItem(){
                Text = "Maximum",
                Value = "Maximum"
            },
            new SelectListItem(){
                Text = "Minimum",
                Value = "Minimum"
            },
            new SelectListItem(){
                Text = "Stabilize",
                Value = "Stabilize"
            }
        };
    }

    public FormPenilaianVM GenerateFormPenilaian(int nik)
    {
        User user = _userRepository.get(nik);
        FormPenilaianVM formPenilaian = new FormPenilaianVM();
        formPenilaian.nik = nik;
        formPenilaian.name = user.Nama;
        formPenilaian.divisi = user.DivisiOrDepartemen;
        formPenilaian.jabatan = user.Jabatan;
        formPenilaian.kpi = GetKpi();
        formPenilaian.unitOfMeasurement = GetUoM();
        formPenilaian.polarisasi = GetPolarisasi();

        return formPenilaian;
    }

    public void BuatPenilaian(FormPenilaianVM formPenilaian, int nik)
    {
        Rekapitulasi rekap = new Rekapitulasi();
        rekap.Nik = formPenilaian.nik;
        rekap.Id = Guid.NewGuid().ToString();
        rekap.Periode = "2024";

        _rekapitulasiRepository.Insert(rekap);


        foreach (var item in formPenilaian.IndikatorUtama)
        {
            IndikatorUtamaKerja indikatorUtama = new IndikatorUtamaKerja();
            indikatorUtama.Id = Guid.NewGuid().ToString();  
            indikatorUtama.RekapId = rekap.Id;
            indikatorUtama.Kpi = item.Kpi;
            indikatorUtama.UoM = item.UoM;
            indikatorUtama.Polarisasi = item.Polarisasi;
            indikatorUtama.Target = item.Target;
            indikatorUtama.Aktual = item.Aktual;
            indikatorUtama.TingkatUnjukKerja = item.TingkatUnjukKerja;
            indikatorUtama.NilaiUnjukKerja = item.NilaiUnjukKerja;
            indikatorUtama.CreatedBy = nik;

            _indikatorUtamaRepository.Insert(indikatorUtama);
        }

        foreach (var item in formPenilaian.IndikatorArea)
        {
            IndikatorArea indikatorArea = new IndikatorArea();
            indikatorArea.Id = Guid.NewGuid().ToString();  
            indikatorArea.RekapId = rekap.Id;
            indikatorArea.Aspek = item.Aspek;
            indikatorArea.Keterangan = item.Keterangan;
            indikatorArea.Target = item.Target;
            indikatorArea.Aktual = item.Aktual;
            indikatorArea.TingkatUnjukKerja = item.TingkatUnjukKerja;
            indikatorArea.NilaiUnjukKerja = item.NilaiUnjukKerja;
            indikatorArea.CreatedBy = nik;

            _indikatorAreaRepository.Insert(indikatorArea);
        }

        KompetensiDasar kompetensiDasar = new KompetensiDasar();
        kompetensiDasar.Id = Guid.NewGuid().ToString();
        kompetensiDasar.RekapId = rekap.Id;
        kompetensiDasar.CustomerFocus = formPenilaian.KompetensiDasar.CustomerFocus;
        kompetensiDasar.Integritas = formPenilaian.KompetensiDasar.Integritas;
        kompetensiDasar.KerjasamaTim = formPenilaian.KompetensiDasar.KerjasamaTim;
        kompetensiDasar.ContinuousImprovement = formPenilaian.KompetensiDasar.ContinuousImprovement;
        kompetensiDasar.WorkExcellence = formPenilaian.KompetensiDasar.WorkExcellence;
        kompetensiDasar.CreatedBy = nik;

        _kompetensiDasarRepository.Insert(kompetensiDasar);

        PerubahanNilai perubahanNilai = new PerubahanNilai();
        perubahanNilai.Id = Guid.NewGuid().ToString();
        perubahanNilai.RekapId = rekap.Id;
        perubahanNilai.LostTimeInjury = formPenilaian.PerubahanNilai.LostTimeInjury;
        perubahanNilai.Project = formPenilaian.PerubahanNilai.Project;
        perubahanNilai.Sga = formPenilaian.PerubahanNilai.Sga;
        perubahanNilai.AuditorOrTrainer = formPenilaian.PerubahanNilai.AuditorOrTrainer;
        perubahanNilai.SuratPeringatan = formPenilaian.PerubahanNilai.SuratPeringatan;
        perubahanNilai.FireIncident = formPenilaian.PerubahanNilai.FireIncident;
        perubahanNilai.CreatedBy = nik;

        _perubahanNilaiRepository.Insert(perubahanNilai);
    }
}
