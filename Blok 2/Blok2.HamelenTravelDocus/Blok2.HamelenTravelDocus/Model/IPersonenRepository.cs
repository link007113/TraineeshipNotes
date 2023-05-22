namespace Blok2.HamelenTravelDocus.Model
{
    public interface IPersonenRepository
    {
        Persoon? GetPersoonByBsn(string bsn);

        IEnumerable<Persoon> GetAllPersons();

        bool InsertNewPersoon(Persoon persoon);

        Medewerker? GetMedewerkerByName(string name);
    }
}