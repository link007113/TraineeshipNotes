namespace Blok2.HamelenTravelDocus.Model;

public partial class Reisdocument
{
    public int DocumentId { get; set; }

    public int PersoonId { get; set; }

    public string DocumentNr { get; set; } = null!;

    public int DocumentTypeId { get; set; }

    public int AanvraagMedewerkerId { get; set; }

    public DateTime AanvraagDatumTijd { get; set; }

    public string AfgiftePlaats { get; set; } = null!;

    public DateTime AfgifteDatum { get; set; }

    public DateTime? VerloopDatum { get; set; }

    public decimal BetaaldePrijs { get; set; }

    public int? DocumentStatusId { get; set; }

    public virtual Medewerker AanvraagMedewerker { get; set; } = null!;

    public virtual DocumentStatus? DocumentStatus { get; set; }

    public virtual DocumentType DocumentType { get; set; } = null!;

    public virtual Persoon Persoon { get; set; } = null!;
}