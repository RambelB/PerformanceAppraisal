using System;
using System.Collections.Generic;

namespace AppraisalDataAccess.Models;

public partial class KompetensiDasar
{
    public string Id { get; set; } = null!;

    public string CustomerFocus { get; set; } = null!;

    public string Integritas { get; set; } = null!;

    public string KerjasamaTim { get; set; } = null!;

    public string ContinuousImprovement { get; set; } = null!;

    public string WorkExcellence { get; set; } = null!;

    public string RekapId { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int? UpdatedBy { get; set; }

    public virtual Rekapitulasi Rekap { get; set; } = null!;
}
