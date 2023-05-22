using System;
using System.Collections.Generic;

namespace Blok2.HamelenTravelDocus.Model;

public partial class DocumentStatus
{
    public int DocumentStatusId { get; set; }

    public string DocumentStatusNaam { get; set; } = null!;

    public virtual ICollection<Reisdocument> Reisdocumenten { get; set; } = new List<Reisdocument>();
}