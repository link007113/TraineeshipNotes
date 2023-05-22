using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok2.HamelenTravelDocus.Model
{
    public interface IPersonenRepository
    {
        Persoon? GetPersoonByBsn(string bsn);

        IEnumerable<Persoon> GetAllPersons();

        void InsertNewPersoon(Persoon persoon);

        Medewerker? GetMedewerkerByName(string name);
    }
}