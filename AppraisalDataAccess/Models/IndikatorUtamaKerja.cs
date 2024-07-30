using System;
using System.Collections.Generic;

namespace AppraisalDataAccess.Models;

public partial class IndikatorUtamaKerja
{
    public string Id { get; set; } = null!;

    public string StrategicObjective { get; set; } = null!;

    /// <summary>
    /// Content of the post
    /// </summary>
    public string Kpi { get; set; } = null!;

    public string UoM { get; set; } = null!;

    public string Polarisasi { get; set; } = null!;

    public int Target { get; set; }

    public int Aktual { get; set; }

    public int TingkatUnjukKerja { get; set; }

    public int NilaiUnjukKerja { get; set; }

    public string RekapId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Kpi KpiNavigation { get; set; } = null!;

    public virtual Rekapitulasi Rekap { get; set; } = null!;
}
