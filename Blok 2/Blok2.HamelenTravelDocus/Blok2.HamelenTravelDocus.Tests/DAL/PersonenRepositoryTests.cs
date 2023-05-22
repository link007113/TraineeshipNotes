using Blok2.HamelenTravelDocus.DAL;
using Blok2.HamelenTravelDocus.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok2.HamelenTravelDocus.Tests.DAL
{
    [TestClass]
    public class PersonenRepositoryTests
    {
        private static DbContextOptions<WegUitHamelenContext> _options;

        [TestInitialize]
        public void Init()
        {
            _options = ContextHelper.GetOptions(true);
            CreateTestData();
        }

        [TestMethod]
        public void GetAllPersonen_ShouldReturnAllPersonen()
        {
            // Arrange
            PersonenRepository personenRepository = new PersonenRepository(_options);
            // Act
            var personen = personenRepository.GetAllPersons();
            // Assert
            Assert.IsTrue(personen.Count() > 0);
        }

        [TestMethod]
        public void GetPersoonByBSN_ShouldResultInPersoonWhenBSNExists()
        {
            // Arrange
            PersonenRepository personenRepository = new PersonenRepository(_options);

            // Act
            var persoon = personenRepository.GetPersoonByBsn("688443059");
            // Assert
            Assert.AreEqual("688443059", persoon?.Bsn);
        }

        [TestMethod]
        public void GetPersoonByBSN_ShouldResultInNullWhenBSNNotExists()
        {
            // Arrange
            PersonenRepository personenRepository = new PersonenRepository(_options);

            // Act
            var persoon = personenRepository.GetPersoonByBsn("6884430598");
            // Assert
            Assert.AreEqual(null, persoon);
        }

        //[TestMethod] // Wordt nu getest door de Init
        //public void InsertNewPersoon_ShouldInsertNewPersoon()
        //{
        //    // Arrange
        //    PersonenRepository personenRepository = new PersonenRepository(_options);
        //    var persoon = GetPersoon();
        //    // Act
        //    personenRepository.InsertNewPersoon(persoon);
        //    // Assert
        //    var persoonFromDb = personenRepository.GetPersoonByBsn(persoon.Bsn);
        //    Assert.AreEqual(persoon.Voornaam, persoonFromDb.Voornaam);
        //    Assert.AreEqual(persoon.Tussenvoegsel, persoonFromDb.Tussenvoegsel);
        //    Assert.AreEqual(persoon.Achternaam, persoonFromDb.Achternaam);
        //    Assert.AreEqual(persoon.OorspronkelijkeNaam, persoonFromDb.OorspronkelijkeNaam);
        //    Assert.AreEqual(persoon.Bsn, persoonFromDb.Bsn);
        //    Assert.AreEqual(persoon.Adres, persoonFromDb.Adres);
        //    Assert.AreEqual(persoon.Woonplaats, persoonFromDb.Woonplaats);
        //    Assert.AreEqual(persoon.Postcode, persoonFromDb.Postcode);
        //    Assert.AreEqual(persoon.Geboorteland, persoonFromDb.Geboorteland);
        //    Assert.AreEqual(persoon.Geboorteplaats, persoonFromDb.Geboorteplaats);
        //}

        [TestMethod]
        public void GetMedeWerkerByName_ShouldReturnMedewerkerWhenExists()
        {
            // Arrange
            PersonenRepository personenRepository = new PersonenRepository(_options);

            // Act
            var medewerker = personenRepository.GetMedewerkerByName("Els");

            // Assert
            Assert.AreEqual("Els", medewerker?.Persoon.Voornaam);
        }

        [TestMethod]
        public void GetMedeWerkerByName_ShouldReturnNullWhenNotExists()
        {
            // Arrange
            PersonenRepository personenRepository = new PersonenRepository(_options);
            // Act
            var medewerker = personenRepository.GetMedewerkerByName("Elsje");
            // Assert
            Assert.AreEqual(null, medewerker);
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
    }
}