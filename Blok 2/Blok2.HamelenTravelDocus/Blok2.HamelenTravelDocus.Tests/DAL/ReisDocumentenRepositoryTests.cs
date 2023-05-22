using Blok2.HamelenTravelDocus.DAL;
using Blok2.HamelenTravelDocus.Model;
using Microsoft.EntityFrameworkCore;

namespace Blok2.HamelenTravelDocus.Tests.DAL
{
    [TestClass]
    public class ReisDocumentenRepositoryTests
    {
        private const string _documentType = "Paspoort";
        private static DbContextOptions<WegUitHamelenContext> _options;
        private static Reisdocument _reisdocument;

        [TestInitialize]
        public void Init()
        {
            _options = ContextHelper.GetOptions(true);
            CreateTestData();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _reisdocument = null;
        }

        [TestMethod]
        public void GetAllOpenReisdocumenten_ShouldReturnAllOpenReisdocumenten()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            // Act
            var reisdocumenten = reisdocumentenRepository.GetAllOpenReisdocumenten();
            // Assert
            Assert.IsTrue(reisdocumenten.Any(r => r.DocumentStatus?.DocumentStatusNaam == "Aangevraagd"));
        }

        [TestMethod]
        public void GetAllOpenReisdocumenten_ShouldReturnAllOpenReisdocumenten_WithCorrectDocumentStatus()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            // Act
            var reisdocumenten = reisdocumentenRepository.GetAllOpenReisdocumenten();
            // Assert
            Assert.IsTrue(reisdocumenten.All(r => r.DocumentStatus?.DocumentStatusNaam != "Opgehaald"));
        }

        [TestMethod]
        public void GetAllReisdocumenten_ShouldReturnAllReisdocumenten()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            // Act
            var reisdocumenten = reisdocumentenRepository.GetAllReisdocumenten();
            // Assert
            Assert.IsTrue(reisdocumenten.Any());
        }

        [TestMethod]
        public void GetReisDocumentByDocumentNumber_ShouldReturnNothingtIfNotExists()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            // Act
            var reisdocumentFromDB = reisdocumentenRepository.GetReisDocumentByDocumentNumber("Bla");
            // Assert
            Assert.AreEqual(null, reisdocumentFromDB);
        }

        [TestMethod]
        public void GetReisDocumentByDocumentNumber_ShouldReturnReisDocumentIfExists()
        {
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);

            // Act
            var reisdocumentFromDB = reisdocumentenRepository.GetReisDocumentByDocumentNumber(_reisdocument.DocumentNr);
            // Assert
            Assert.AreEqual(_reisdocument.DocumentNr, reisdocumentFromDB?.DocumentNr);
        }

        [TestMethod]
        public void GetReisDocumentStatus_ReturnsExistingDocumentStatus()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            // Act
            var documentStatus = reisdocumentenRepository.GetReisDocumentStatus("Aangevraagd");
            // Assert
            Assert.AreEqual("Aangevraagd", documentStatus?.DocumentStatusNaam);
        }

        [TestMethod]
        public void GetReisDocumentStatus_ReturnsNullWhenDocumentStatusNotFound()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            // Act
            var documentStatus = reisdocumentenRepository.GetReisDocumentStatus("Bla");
            // Assert
            Assert.AreEqual(null, documentStatus);
        }

        [TestMethod]
        public void GetReisDocumentType_ReturnsExistingDocumentType()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            // Act
            var documentType = reisdocumentenRepository.GetReisDocumentType(_documentType);
            // Assert
            Assert.AreEqual("Paspoort", documentType?.DocumentTypeNaam);
        }

        [TestMethod]
        public void GetReisDocumentType_ReturnsNullWhenDocumentTypeNotFound()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            // Act
            var documentType = reisdocumentenRepository.GetReisDocumentType("Bla");
            // Assert
            Assert.AreEqual(null, documentType);
        }

        [TestMethod]
        public void InsertNewReisDocument_DoesNotAddReisdocumentWhenMedewerkerNotFound()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            Reisdocument reisdocument = new Reisdocument();
            FillReisDocument(reisdocumentenRepository, reisdocument);

            // Act
            var result = reisdocumentenRepository.InsertNewReisDocument(reisdocument, "209175175", "Jonathan", _documentType);

            // Assert
            Assert.AreEqual(false, result);
            Assert.IsFalse(reisdocumentenRepository.GetAllReisdocumenten().Contains(reisdocument));
        }

        [TestMethod]
        public void InsertNewReisDocument_DoesNotAddReisdocumentWhenPersoonNotFound()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            Reisdocument reisdocument = new Reisdocument();
            FillReisDocument(reisdocumentenRepository, reisdocument);

            // Act
            var result = reisdocumentenRepository.InsertNewReisDocument(reisdocument, "209175176", "Els", _documentType);

            // Assert
            Assert.AreEqual(false, result);
            Assert.IsFalse(reisdocumentenRepository.GetAllReisdocumenten().Contains(reisdocument));
        }

        [TestMethod]
        public void InsertNewReisDocument_DoesNotAddReisdocumentWhenTypeNotFound()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            Reisdocument reisdocument = new Reisdocument();
            FillReisDocument(reisdocumentenRepository, reisdocument);

            // Act
            var result = reisdocumentenRepository.InsertNewReisDocument(reisdocument, GetPersoon().Bsn, GetMedewerker().Voornaam, "Bla");

            // Assert
            Assert.AreEqual(false, result);
            Assert.IsFalse(reisdocumentenRepository.GetAllReisdocumenten().Contains(reisdocument));
        }

        [TestMethod]
        public void UpdateStatusReisdocument_DoesNotUpdateStatusWhenReisdocumentNotFound()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);

            // Act
            var result = reisdocumentenRepository.UpdateStatusReisdocument(-1, "Aangevraagd");
            // Assert
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void UpdateStatusReisdocument_DoesNotUpdateStatusWhenStatusNotFound()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);

            // Act
            var result = reisdocumentenRepository.UpdateStatusReisdocument(_reisdocument.DocumentId, "Onbekend");

            // Assert
            Assert.AreEqual(false, result);
            Assert.AreEqual("Aangevraagd", reisdocumentenRepository.GetReisDocumentByDocumentNumber(_reisdocument.DocumentNr).DocumentStatus.DocumentStatusNaam);
        }

        [TestMethod]
        public void UpdateStatusReisdocument_SetsNewStatusAndSavesReisdocument()
        {
            // Arrange
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);

            // Act
            reisdocumentenRepository.UpdateStatusReisdocument(_reisdocument.DocumentId, "Opgehaald");
            // Assert
            Assert.AreEqual("Opgehaald", reisdocumentenRepository.GetAllReisdocumenten().First(r => r.DocumentId == _reisdocument.DocumentId).DocumentStatus.DocumentStatusNaam);
        }

        [TestMethod]
        public void DeleteReisDocument_ExistingId_DeletesReisdocumentAndReturnsTrue()
        {
            // Arrange
            var reisdocumentId = _reisdocument.DocumentId;
            var reisdocumentNummer = _reisdocument.DocumentNr;
            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            // Act
            bool result = reisdocumentenRepository.DeleteReisDocument(reisdocumentId);

            // Assert
            Assert.IsTrue(result);
            // Verify that the reisdocument was deleted from the database
            Assert.IsNull(reisdocumentenRepository.GetReisDocumentByDocumentNumber(reisdocumentNummer));
        }

        [TestMethod]
        public void DeleteReisDocument_NonExistingId_ReturnsFalse()
        {
            // Arrange
            var reisdocumentId = -1;

            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);

            // Act
            bool result = reisdocumentenRepository.DeleteReisDocument(reisdocumentId);

            // Assert
            Assert.IsFalse(result);
        }

        #region TestHelpers

        private static void FillReisDocument(ReisdocumentenRepository reisdocumentenRepository, Reisdocument reisdocument)
        {
            DateTime now = DateTime.Now;
            var documentType = reisdocumentenRepository.GetReisDocumentType(_documentType);
            reisdocument.AanvraagDatumTijd = now;
            reisdocument.AfgifteDatum = now.AddDays(14);
            reisdocument.VerloopDatum = now.AddDays(documentType.GeldigheidsduurInDagen);
            reisdocument.AfgiftePlaats = "TestPlaats";
            Random rand = new Random();
            int random = rand.Next(100, 999);
            string voornaam = GetPersoon().Voornaam;
            string achternaam = GetPersoon().Achternaam;
            reisdocument.DocumentNr = new string($"" +
                               $"{voornaam.ToUpper()[0]}" +
                                              $"{achternaam.ToUpper()[0]}" +
                                                             $"{achternaam.ToUpper()[1]}-{random}");
            reisdocument.BetaaldePrijs = documentType.Prijs;
        }

        internal static void CreateTestData()
        {
            PersonenRepository personenRepository = new PersonenRepository(_options);
            if (personenRepository.GetPersoonByBsn(GetPersoon().Bsn) == null)
            {
                personenRepository.InsertNewPersoon(GetPersoon());
            }
            if (personenRepository.GetPersoonByBsn(GetMedewerker().Bsn) == null)
            {
                personenRepository.InsertNewPersoon(GetMedewerker());

                using (var context = ContextHelper.GetContext(_options))
                {
                    Medewerker medewerker = new Medewerker();
                    medewerker.PersoonId = personenRepository.GetPersoonByBsn(GetMedewerker().Bsn).PersoonId;
                    medewerker.Afdeling = new Afdeling();
                    medewerker.Afdeling.Naam = "TestAfdeling";
                    context.Medewerkers.Add(medewerker);
                    context.SaveChanges();
                }
            }

            ReisdocumentenRepository reisdocumentenRepository = new ReisdocumentenRepository(_options);
            Reisdocument reisdocument = new Reisdocument();

            using (var context = ContextHelper.GetContext(_options))
            {
                DocumentType documentType = new DocumentType();
                documentType.DocumentTypeNaam = _documentType;
                documentType.GeldigheidsduurInDagen = 3652;
                documentType.Prijs = 58.85M;
                context.DocumentTypes.Add(documentType);
                DocumentStatus documentStatusA = new DocumentStatus();
                documentStatusA.DocumentStatusNaam = "Aangevraagd";
                context.DocumentStatussen.Add(documentStatusA);
                DocumentStatus documentStatusO = new DocumentStatus();
                documentStatusO.DocumentStatusNaam = "Opgehaald";
                context.DocumentStatussen.Add(documentStatusO);
                context.SaveChanges();
            }

            FillReisDocument(reisdocumentenRepository, reisdocument);
            reisdocumentenRepository.InsertNewReisDocument(reisdocument, GetPersoon().Bsn, GetMedewerker().Voornaam, _documentType);
            _reisdocument = reisdocument;
        }

        internal static Persoon GetPersoon()
        {
            return new Persoon
            {
                Voornaam = "Bob",
                Tussenvoegsel = "de",
                Achternaam = "Tester",
                OorspronkelijkeNaam = "火億王",
                Bsn = "688443059",
                Adres = "Teststraat 1",
                Woonplaats = "Hamelen",
                Postcode = "7312NE",
                Geboorteland = "NL",
                Geboorteplaats = "Hamelen",
            };
        }

        internal static Persoon GetMedewerker()
        {
            return new Persoon
            {
                Voornaam = "Els",
                Achternaam = "Jansen",
                OorspronkelijkeNaam = "火億王",
                Bsn = "668093924",
                Adres = "Kerkstraat 1",
                Woonplaats = "Hamelen",
                Postcode = "1234 AB",
                Geboorteland = "NL",
                Geboorteplaats = "Hamelen",
            };
        }

        #endregion TestHelpers
    }
}