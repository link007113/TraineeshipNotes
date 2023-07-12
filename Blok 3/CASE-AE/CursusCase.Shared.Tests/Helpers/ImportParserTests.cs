using CursusCase.Shared.Exceptions;
using CursusCase.Shared.Helpers;

namespace CursusCase.Shared.Tests.Helpers
{
    [TestClass]
    public class ImportParserTests
    {
        private ImportParser _importParser;
        private string _validImportString;

        private string _notValidImportString;

        [TestInitialize]
        public void Init()

        {
            _importParser = new ImportParser();
            _validImportString = @"Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 8/10/2018

Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 15/10/2018

Titel: Java Persistence API
Cursuscode: JPA
Duur: 2 dagen
Startdatum: 15/10/2018

Titel: Java Persistence API
Cursuscode: JPA
Duur: 2 dagen
Startdatum: 8/10/2018

Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 8/10/2018";

            _notValidImportString = @"Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 8/10/2018
Titel: Java Persistence API
Cursuscode: JPA
Duur: 2 dagen
Startdatum: 10/10/2018

";
        }

        [TestMethod]
        public void Import_ValidInput_ShouldParseCursusInstances()
        {
            // Arrange
            string[] lines = _validImportString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Act
            List<Models.CourseInstance> result = _importParser.ParseLinesToCursus(lines);

            // Assert
            Assert.AreEqual(5, result.Count);
        }

        [TestMethod]
        public void Import_InvalidInput_MissingFields_ShouldThrowImportException()
        {
            // Arrange
            string[] lines = _notValidImportString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            // Act
            void act()
            {
                List<Models.CourseInstance> result = _importParser.ParseLinesToCursus(lines);
            }

            // Assert
            Assert.ThrowsException<ImportException>(act);
        }
    }
}