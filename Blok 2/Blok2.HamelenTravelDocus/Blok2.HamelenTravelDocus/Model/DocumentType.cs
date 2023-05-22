namespace Blok2.HamelenTravelDocus.Model;

public partial class DocumentType
{
    public int DocumentTypeId { get; set; }

    public string DocumentTypeNaam { get; set; } = null!;

    public decimal Prijs { get; set; }

    public int GeldigheidsduurInDagen { get; set; }

    public virtual ICollection<Reisdocument> Reisdocumenten { get; set; } = new List<Reisdocument>();
}