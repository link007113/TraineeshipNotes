using Blok2.HamelenTravelDocus.Helpers;

namespace Blok2.HamelenTravelDocus.Model;

public partial class Persoon
{
    public int PersoonId { get; set; }

    public string Voornaam { get; set; } = null!;

    public string Achternaam { get; set; } = null!;

    public string? Tussenvoegsel { get; set; }

    public string VolledigeNaam
    {
        get
        {
            var array = new[] { Voornaam, Tussenvoegsel, Achternaam };
            return string.Join(" ", array.Where(s => !string.IsNullOrEmpty(s)));
        }
    }

    public string Bsn { get; set; } = null!;

    public bool BsnIsValid
    {
        get
        {
            return BSNValidator.ValidateBSN(Bsn);
        }
    }

    public string Adres { get; set; } = null!;

    public string Postcode { get; set; } = null!;

    public string Woonplaats { get; set; } = null!;

    public string OorspronkelijkeNaam { get; set; } = null!;

    public string Geboorteplaats { get; set; } = null!;

    public string Geboorteland { get; set; } = null!;

    public virtual ICollection<Reisdocument> Reisdocumenten { get; set; } = new List<Reisdocument>();
    public virtual ICollection<Medewerker> Medewerkers { get; set; } = new List<Medewerker>();
}