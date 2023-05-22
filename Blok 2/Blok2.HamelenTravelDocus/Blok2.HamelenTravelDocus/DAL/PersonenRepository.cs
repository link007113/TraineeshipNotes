using Blok2.HamelenTravelDocus.Model;
using Microsoft.EntityFrameworkCore;

namespace Blok2.HamelenTravelDocus.DAL
{
    public class PersonenRepository : IPersonenRepository
    {
        private DbContextOptions<WegUitHamelenContext> _options;

        public PersonenRepository(DbContextOptions<WegUitHamelenContext> options)
        {
            _options = options;
            using (var context = ContextHelper.GetContext(_options))
            {
                context.Database.EnsureCreated();
            }
        }

        public Persoon? GetPersoonByBsn(string bsn) =>
            ContextHelper.GetContext(_options).Personen
          .AsNoTracking()
          .Include(p => p.Reisdocumenten)
          .ThenInclude(r => r.DocumentType)
          .Include(p => p.Reisdocumenten)
          .ThenInclude(r => r.DocumentStatus)
          .FirstOrDefault(p => p.Bsn == bsn);

        public IEnumerable<Persoon> GetAllPersons() =>
            ContextHelper.GetContext(_options).Personen
          .AsNoTracking()
          .Include(p => p.Reisdocumenten)
          .ThenInclude(r => r.DocumentType)
          .Include(p => p.Reisdocumenten)
          .ThenInclude(r => r.DocumentStatus)
          .OrderBy(p => p.Voornaam);

        public bool InsertNewPersoon(Persoon persoon)
        {
            using (var context = ContextHelper.GetContext(_options))
            {
                bool canInsert = !context.Personen
                                .Any(p => p.Bsn == persoon.Bsn
                                       && p.Voornaam == persoon.Voornaam
                                       && p.Tussenvoegsel == persoon.Tussenvoegsel
                                       && p.Achternaam == persoon.Achternaam);

                if (canInsert)
                {
                    context.Personen.Add(persoon);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public Medewerker? GetMedewerkerByName(string name) =>
            ContextHelper.GetContext(_options).Medewerkers
                .AsNoTracking()
                .Include(m => m.Persoon)
                .FirstOrDefault(m => m.Persoon.Voornaam == name);
    }
}