using System;
using System.Collections.Generic;

namespace Blok2.HamelenTravelDocus.Model;

public partial class Medewerker
{
    public int MedewerkerId { get; set; }

    public int PersoonId { get; set; }

    public int AfdelingId { get; set; }

    public int? ManagerId { get; set; }

    public virtual Afdeling Afdeling { get; set; } = null!;

    public virtual ICollection<Medewerker> InverseManager { get; set; } = new List<Medewerker>();

    public virtual Medewerker? Manager { get; set; }

    public virtual Persoon Persoon { get; set; } = null!;

    public virtual ICollection<Reisdocument> Reisdocumenten { get; set; } = new List<Reisdocument>();
}