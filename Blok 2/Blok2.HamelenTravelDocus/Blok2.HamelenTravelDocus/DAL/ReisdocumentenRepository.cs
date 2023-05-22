using Blok2.HamelenTravelDocus.Model;
using Microsoft.EntityFrameworkCore;

namespace Blok2.HamelenTravelDocus.DAL
{
    public class ReisdocumentenRepository : IReisdocumentenRepository
    {
        private DbContextOptions<WegUitHamelenContext> _options;

        public ReisdocumentenRepository(DbContextOptions<WegUitHamelenContext> options)
        {
            _options = options;
            using (var context = ContextHelper.GetContext(_options))
            {
                context.Database.EnsureCreated();
            }
        }

        public IEnumerable<Reisdocument> GetAllOpenReisdocumenten() =>
            ContextHelper.GetContext(_options).Reisdocumenten
                .AsNoTracking()
                .Include(r => r.DocumentType)
                .Include(r => r.DocumentStatus)
                .Include(r => r.Persoon)
                .Include(r => r.AanvraagMedewerker)
                .Where(r => r.DocumentStatus.DocumentStatusNaam == "Aangevraagd");

        public IEnumerable<Reisdocument> GetAllReisdocumenten() =>
            ContextHelper.GetContext(_options).Reisdocumenten
                .AsNoTracking()
                .Include(r => r.DocumentType)
                .Include(r => r.DocumentStatus)
                .Include(r => r.Persoon)
                .Include(r => r.AanvraagMedewerker);

        public bool UpdateStatusReisdocument(int reisdocumentId, string status)
        {
            using (var context = ContextHelper.GetContext(_options))
            {
                Reisdocument? reisdocument = context.Reisdocumenten.FirstOrDefault(r => r.DocumentId == reisdocumentId);
                var documentStatus = context.DocumentStatussen.FirstOrDefault(r => r.DocumentStatusNaam == status);
                int documentStatusId;
                if (documentStatus == null)
                {
                    documentStatusId = 0;
                }
                else
                {
                    documentStatusId = documentStatus.DocumentStatusId;
                }

                if (reisdocument == null)
                {
                    return false;
                }
                if (documentStatusId == 0)
                {
                    return false;
                }
                reisdocument.DocumentStatusId = documentStatusId;
                context.SaveChanges();
                return true;
            }
        }

        public bool InsertNewReisDocument(Reisdocument reisdocument, string bsn, string medewerkerNaam, string type)
        {
            using (var context = ContextHelper.GetContext(_options))
            {
                PersonenRepository personenRepository = new PersonenRepository(_options);

                Persoon? persoon = personenRepository.GetPersoonByBsn(bsn);
                if (persoon != null)
                {
                    reisdocument.PersoonId = persoon.PersoonId;
                }
                else
                {
                    return false;
                }

                Medewerker? medewerker = personenRepository.GetMedewerkerByName(medewerkerNaam);
                if (medewerker != null)
                {
                    reisdocument.AanvraagMedewerkerId = medewerker.MedewerkerId;
                }
                else
                {
                    return false;
                }

                DocumentType? documentType = GetReisDocumentType(type);
                if (documentType != null)
                {
                    reisdocument.DocumentTypeId = documentType.DocumentTypeId;
                }
                else
                {
                    return false;
                }

                reisdocument.DocumentStatusId = GetReisDocumentStatus("Aangevraagd").DocumentStatusId;
                context.Reisdocumenten.Add(reisdocument);
                context.SaveChanges();
                return true;
            }
        }

        public DocumentType GetReisDocumentType(string type)
        => ContextHelper.GetContext(_options).DocumentTypes.FirstOrDefault(r => r.DocumentTypeNaam == type)!;

        public DocumentStatus GetReisDocumentStatus(string status)
      => ContextHelper.GetContext(_options).DocumentStatussen.FirstOrDefault(r => r.DocumentStatusNaam == status)!;

        public Reisdocument? GetReisDocumentByDocumentNumber(string documentNumber) =>
            ContextHelper.GetContext(_options).Reisdocumenten
                .AsNoTracking()
                .Include(r => r.DocumentStatus)
                .FirstOrDefault(r => r.DocumentNr == documentNumber);

        public bool DeleteReisDocument(int reisdocumentId)
        {
            using (var context = ContextHelper.GetContext(_options))
            {
                Reisdocument? reisdocument = context.Reisdocumenten.FirstOrDefault(r => r.DocumentId == reisdocumentId);
                if (reisdocument == null)
                {
                    return false;
                }
                context.Reisdocumenten.Remove(reisdocument);
                context.SaveChanges();
                return true;
            }
        }
    }
}