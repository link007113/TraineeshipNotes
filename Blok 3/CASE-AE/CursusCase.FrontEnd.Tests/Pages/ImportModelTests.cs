using CursusCase.FrontEnd.Pages;
using CursusCase.Shared.Helpers;
using CursusCase.Shared.Models;
using CursusCase.Shared.Repositories;
using CursusCase.Shared.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using System.Text;

namespace CursusCase.FrontEnd.Tests.Pages
{
    [TestClass]
    public class ImportModelTests
    {
        private Mock<ICursusInstanceRepo> _cursusInstanceRepoMock;
        private ImportModel _model;

        [TestInitialize]
        public void Setup()
        {
            _cursusInstanceRepoMock = new Mock<ICursusInstanceRepo>();
            _model = new ImportModel(_cursusInstanceRepoMock.Object);        }

        [TestMethod]
        public void OnPostSaveList_WithValidData_AddsInstancesAndDisplaysMessage()
        {
            // Arrange
            List<CourseInstance> cursusInstances = GetInstances();
            _model.CursusInstances = cursusInstances;

            CourseInstanceOperationResult resultDto = new CourseInstanceOperationResult
            {
                CursusInstances = cursusInstances,
                NewCourses = 2,
                NewInstances = 2
            };
            _cursusInstanceRepoMock
                .Setup(repo => repo.AddInstances(cursusInstances))
                .Returns(resultDto);

            // Act
            IActionResult result = _model.OnPostSaveList();

            // Assert
            Assert.IsInstanceOfType(result, typeof(PageResult));
            Assert.IsTrue(_model.IsSavedPressed);
            CollectionAssert.AreEqual(cursusInstances, _model.CursusInstances.ToList());
            Assert.AreEqual(
                $"De volgende gegevens zijn geïmporteerd.\nEr zijn {resultDto.NewCourses} cursussen aangemaakt.\nEr zijn {resultDto.NewInstances} instanties aangemaakt.",
                _model.Message
            );
            Assert.AreEqual(0, _model.Errors.Count);
        }

        [TestMethod]
        public void OnPostSaveList_WithInvalidData_DisplaysErrors()
        {
            // Arrange
            List<CourseInstance> cursusInstances = GetInstances();
            _model.CursusInstances = cursusInstances;

            List<string> errors = new List<string> { "Error 1", "Error 2" };
            CourseInstanceOperationResult resultDto = new CourseInstanceOperationResult { Errors = errors };
            _cursusInstanceRepoMock
                .Setup(repo => repo.AddInstances(cursusInstances))
                .Returns(resultDto);

            // Act
            IActionResult result = _model.OnPostSaveList();

            // Assert
            Assert.IsInstanceOfType(result, typeof(PageResult));
            Assert.IsTrue(_model.IsSavedPressed);
            Assert.IsNull(_model.CursusInstances);
            CollectionAssert.AreEqual(errors, _model.Errors);
        }

        [TestMethod]
        public void OnPostImportFile_WithValidFile_ParsesLinesAndSetsCursusInstances()
        {
            // Arrange
            DateTime dateTime = DateTime.MinValue;

            string filePath = Path.GetTempFileName();
            string fileContent = GetFileString();
            string[] lines = fileContent.Split('\n');
            List<CourseInstance> parsedInstances = GetInstances();
            _cursusInstanceRepoMock
                .Setup(repo => repo.AddInstances(parsedInstances))
                .Returns(new CourseInstanceOperationResult());
            byte[] byteArray = Encoding.ASCII.GetBytes(fileContent);
            MemoryStream stream = new MemoryStream(byteArray);

            FormFile import = new FormFile(stream, 0, stream.Length, "Import", filePath);
            _model.Import = import;
            // Act
            IActionResult result = _model.OnPostImportFile(dateTime, dateTime);

            // Assert
            Assert.IsInstanceOfType(result, typeof(PageResult));
            Assert.AreEqual(parsedInstances.Count(), _model.CursusInstances.ToList().Count());
            Assert.AreEqual(
                parsedInstances[0].Cursus.Code,
                _model.CursusInstances.FirstOrDefault().Cursus.Code
            );
            Assert.AreEqual(
                parsedInstances[0].Cursus.Title,
                _model.CursusInstances.FirstOrDefault().Cursus.Title
            );
            Assert.AreEqual(
                parsedInstances[0].StartDate,
                _model.CursusInstances.FirstOrDefault().StartDate
            );
            _cursusInstanceRepoMock.Verify(repo => repo.AddInstances(parsedInstances), Times.Never);

            File.Delete(filePath);
        }

        [TestMethod]
        public void OnPostImportFile_WithInvalidFile_DisplaysErrors()
        {
            // Arrange
            _model.Import = null;
            DateTime dateTime = DateTime.MinValue;
            // Act
            IActionResult result = _model.OnPostImportFile(dateTime, dateTime);

            // Assert
            Assert.IsInstanceOfType(result, typeof(PageResult));
            Assert.IsNull(_model.CursusInstances);
            Assert.AreEqual(0, _model.Errors.Count);
        }

        public static List<CourseInstance> GetInstances()
        {
            string input = GetFileString();
            ImportParser parser = new ImportParser();
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return parser.ParseLinesToCursus(lines);
        }

        private static string GetFileString()
        {
            return @"Titel: C# Programmeren
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
        }
    }
}