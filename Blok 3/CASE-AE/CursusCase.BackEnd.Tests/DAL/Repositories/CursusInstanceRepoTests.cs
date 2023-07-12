using CursusCase.Backend.DAL.Context;
using CursusCase.Backend.DAL.Repositories;
using CursusCase.Shared.Helpers;
using CursusCase.Shared.Models;
using CursusCase.Shared.Results;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CursusCase.BackEnd.Tests.DAL.Repositories
{
    [TestClass]
    public class CursusInstanceRepoTests
    {
        private CursusInstanceRepo _repository;

        [TestInitialize]
        public void TestInitialize()
        {
            SqliteConnection connection = new SqliteConnection("Filename=:memory:");
            connection.Open();

            DbContextOptions<CursusContext> options = new DbContextOptionsBuilder<CursusContext>()
                .UseSqlite(connection)
                .Options;

            CursusContext dbContext = new CursusContext(options);
            dbContext.Database.EnsureCreated();

            string input =
                @"Titel: C# Programmeren
Cursuscode: CNETIN
Duur: 5 dagen
Startdatum: 8/10/2018

Titel: Java Persistence API
Cursuscode: JPA
Duur: 2 dagen
Startdatum: 8/10/2018
";

            ImportParser parser = new ImportParser();
            string[] lines = input.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            List<CourseInstance> instances = parser.ParseLinesToCursus(lines);

            dbContext.AddRange(instances);
            dbContext.SaveChanges();

            _repository = new CursusInstanceRepo(dbContext);
        }

        [TestMethod]
        public void AddInstances_ReturnsCursusInstanceDTOWithAddedInstances()
        {
            // Arrange
            List<CourseInstance> instances = GetTestInstances();

            // Act
            CourseInstanceOperationResult result = _repository.AddInstances(instances);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CourseInstanceOperationResult));
            Assert.AreEqual(2, result.NewCourses);
            Assert.AreEqual(2, result.NewInstances);
            Assert.AreEqual(0, result.Errors.Count);
            Assert.AreEqual(2, result.CursusInstances.Count());
        }

        [TestMethod]
        public void AddInstances_ReturnsCursusInstanceDTOWithError_ForInvalidInstanceDuration()
        {
            // Arrange
            List<CourseInstance> instances = GetTestInstances().ToList();
            CourseInstance invalidInstance = new CourseInstance
            {
                Cursus = new Course
                {
                    Title = "Test 3",
                    Code = "TESTC",
                    DurationInDays = 6
                },
                StartDate = new DateTime(2023, 6, 19)
            };
            instances.Add(invalidInstance);

            // Act
            CourseInstanceOperationResult result = _repository.AddInstances(instances);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CourseInstanceOperationResult));
            Assert.AreEqual(2, result.NewCourses);
            Assert.AreEqual(2, result.NewInstances);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.AreEqual(
                "De duur van de cursus mag niet meer dan 5 dagen bedragen.",
                result.Errors[0]
            );
            Assert.AreEqual(2, result.CursusInstances.Count());
        }

        [TestMethod]
        public void AddInstances_ReturnsCursusInstanceDTOWithError_ForInvalidInstanceStartDate()
        {
            // Arrange
            List<CourseInstance> instances = GetTestInstances();
            CourseInstance invalidInstance = new CourseInstance
            {
                Cursus = new Course
                {
                    Title = "Test 4",
                    Code = "TESTD",
                    DurationInDays = 4
                },
                StartDate = new DateTime(2023, 6, 22)
            };
            instances.Add(invalidInstance);

            // Act
            CourseInstanceOperationResult result = _repository.AddInstances(instances);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CourseInstanceOperationResult));
            Assert.AreEqual(3, result.NewCourses);
            Assert.AreEqual(2, result.NewInstances);
            Assert.AreEqual(1, result.Errors.Count);
            Assert.IsTrue(
                result.Errors[0].Contains(
                    $"De cursus ({invalidInstance.Cursus.Code}) moet gepland worden binnen een week (maandag t/m vrijdag)."
                )
            );
            Assert.AreEqual(2, result.CursusInstances.Count());
        }

        [TestMethod]
        public void GetAllInstances_ReturnsCursusInstanceDTOWithAllInstances()
        {
            // Act
            CourseInstanceOperationResult result = _repository.GetAllInstances();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CourseInstanceOperationResult));
            Assert.AreEqual(0, result.NewCourses);
            Assert.AreEqual(0, result.NewInstances);
            Assert.AreEqual(0, result.Errors.Count);
            Assert.AreEqual(2, result.CursusInstances.Count());
        }

        [TestMethod]
        public void GetInstancesBySearchPerPeriod_ReturnsCursusInstanceDTOWithFilteredInstances()
        {
            // Arrange
            DateTime dateFrom = new DateTime(2018, 10, 8);
            DateTime dateTill = new DateTime(2018, 10, 12);

            // Act
            CourseInstanceOperationResult result = _repository.GetInstancesBySearchPerPeriod(
                dateFrom,
                dateTill
            );

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CourseInstanceOperationResult));
            Assert.AreEqual(0, result.NewCourses);
            Assert.AreEqual(0, result.NewInstances);
            Assert.AreEqual(0, result.Errors.Count);
            Assert.AreEqual(2, result.CursusInstances.Count());
        }

        private List<CourseInstance> GetTestInstances()
        {
            CourseInstance instance1 = new CourseInstance
            {
                Cursus = new Course
                {
                    Title = "Test 1",
                    Code = "TESTA",
                    DurationInDays = 5
                },
                StartDate = new DateTime(2023, 6, 19)
            };

            CourseInstance instance2 = new CourseInstance
            {
                Cursus = new Course
                {
                    Title = "Test 2",
                    Code = "TESTB",
                    DurationInDays = 2
                },
                StartDate = new DateTime(2023, 6, 20)
            };

            return new List<CourseInstance> { instance1, instance2 };
        }
    }
}