using System;
using System.Collections.Generic;

namespace Blok2.HamelenTravelDocus.Model;

public partial class Afdeling
{
    public int AfdelingId { get; set; }

    public string? Naam { get; set; }

    public virtual ICollection<Medewerker> Medewerkers { get; set; } = new List<Medewerker>();
}