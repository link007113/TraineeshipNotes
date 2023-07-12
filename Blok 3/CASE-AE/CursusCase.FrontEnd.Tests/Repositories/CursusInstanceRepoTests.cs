using CursusCase.FrontEnd.Repositories;
using CursusCase.Shared.Models;
using CursusCase.Shared.Results;
using Flurl.Http.Testing;

namespace CursusCase.FrontEnd.Tests.Repositories
{
    [TestClass]
    public class CursusInstanceRepoTests
    {
        private CursusInstanceRepo _cursusInstanceRepo;
        private HttpTest _httpTest;

        [TestInitialize]
        public void TestInitialize()
        {
            _httpTest = new HttpTest();
            _cursusInstanceRepo = new CursusInstanceRepo();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _httpTest.Dispose();
        }

        [TestMethod]
        public void AddInstances_InputInstances_ExpectCursusInstanceDTO()
        {
            // Arrange
            List<CourseInstance> instances = new List<CourseInstance>();
            CourseInstanceOperationResult mockWrapper = new CourseInstanceOperationResult();

            _httpTest.RespondWithJson(mockWrapper);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.AddInstances(instances);

            // Assert
            _httpTest.ShouldHaveCalled("https://localhost:7236/api/cursusinstanties/new")
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(instances);

            Assert.AreEqual(mockWrapper.GetType(), result.GetType());
        }

        [TestMethod]
        public void AddInstances_InputNull_ExpectCursusInstanceDTOWithError()
        {
            // Arrange
            _httpTest.RespondWith("Error", 500);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.AddInstances(null);

            // Assert
            _httpTest.ShouldHaveCalled("https://localhost:7236/api/cursusinstanties/new")
                .WithVerb(HttpMethod.Post);
            Assert.IsTrue(result.Errors.Any());
        }

        [TestMethod]
        public void GetAllInstances_HappyFlow_ExpectCursusInstanceDTO()
        {
            // Arrange
            CourseInstanceOperationResult mockWrapper = new CourseInstanceOperationResult();
            _httpTest.RespondWithJson(mockWrapper);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.GetAllInstances();

            // Assert
            _httpTest.ShouldHaveCalled("https://localhost:7236/api/cursusinstanties")
                .WithVerb(HttpMethod.Get);
            Assert.AreEqual(mockWrapper.GetType(), result.GetType());
        }

        [TestMethod]
        public void GetAllInstances_SadFlow_ExpectCursusInstanceDTOWithError()
        {
            // Arrange
            _httpTest.RespondWith("Error", 500);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.GetAllInstances();

            // Assert
            _httpTest.ShouldHaveCalled("https://localhost:7236/api/cursusinstanties")
                .WithVerb(HttpMethod.Get);
            Assert.IsTrue(result.Errors.Any());
        }

        [TestMethod]
        public void GetInstancesBySearchPerWeekAndYear_InputWeekAndYear_ExpectCursusInstanceDTO()
        {
            // Arrange
            CourseInstanceOperationResult mockWrapper = new CourseInstanceOperationResult();
            int year = 2023;
            int week = 25;
            _httpTest.RespondWithJson(mockWrapper);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.GetInstancesBySearchPerWeekAndYear(year, week);

            // Assert
            _httpTest.ShouldHaveCalled($"https://localhost:7236/api/cursusinstanties/{year}/{week}")
                .WithVerb(HttpMethod.Get);
            Assert.AreEqual(mockWrapper.GetType(), result.GetType());
        }

        [TestMethod]
        public void GetInstancesBySearchPerWeekAndYear_InvalidInput_ExpectCursusInstanceDTOWithError()
        {
            // Arrange
            int year = 0;
            int week = 0;
            _httpTest.RespondWith("Error", 500);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.GetInstancesBySearchPerWeekAndYear(year, week);

            // Assert
            _httpTest.ShouldHaveCalled("*")
                .WithVerb(HttpMethod.Get);
            Assert.IsTrue(result.Errors.Any());
        }

        [TestMethod]
        public void GetInstancesBySearchPerPeriod_InputPeriod_ExpectCursusInstanceDTO()
        {
            // Arrange
            CourseInstanceOperationResult mockWrapper = new CourseInstanceOperationResult();
            DateTime dateFrom = DateTime.Now;
            DateTime dateTo = DateTime.Now.AddMonths(1);
            _httpTest.RespondWithJson(mockWrapper);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.GetInstancesBySearchPerPeriod(dateFrom, dateTo);

            // Assert
            _httpTest.ShouldHaveCalled("https://localhost:7236/api/cursusinstanties/date")
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(new Period() { DateFrom = dateFrom, DateTo = dateTo });
            Assert.AreEqual(mockWrapper.GetType(), result.GetType());
        }

        [TestMethod]
        public void GetInstancesBySearchPerPeriod_InvalidInput_ExpectCursusInstanceDTOWithError()
        {
            // Arrange
            DateTime dateFrom = DateTime.Now;
            DateTime dateTo = DateTime.Now.AddMonths(-1);
            _httpTest.RespondWith("Error", 500);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.GetInstancesBySearchPerPeriod(dateFrom, dateTo);

            // Assert
            _httpTest.ShouldHaveCalled("*")
                .WithVerb(HttpMethod.Post);
            Assert.IsTrue(result.Errors.Any());
        }

        [TestMethod]
        public void GetCursusInstanceById_InputId_ExpectCursusInstanceDTO()
        {
            // Arrange
            CourseInstanceOperationResult mockWrapper = new CourseInstanceOperationResult();
            int id = 1;
            _httpTest.RespondWithJson(mockWrapper);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.GetCursusInstanceById(id);

            // Assert
            _httpTest.ShouldHaveCalled($"https://localhost:7236/api/cursusinstanties/{id}")
                .WithVerb(HttpMethod.Get);
            Assert.AreEqual(mockWrapper.GetType(), result.GetType());
        }

        [TestMethod]
        public void GetCursusInstanceById_InvalidInput_ExpectCursusInstanceDTOWithError()
        {
            // Arrange
            int id = 0;
            _httpTest.RespondWith("Error", 500);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.GetCursusInstanceById(id);

            // Assert
            _httpTest.ShouldHaveCalled("*")
                .WithVerb(HttpMethod.Get);
            Assert.IsTrue(result.Errors.Any());
        }

        [TestMethod]
        public void AddStudent_InputStudentAndId_ExpectCursusInstanceDTO()
        {
            // Arrange
            CourseInstanceOperationResult mockWrapper = new CourseInstanceOperationResult();
            Student student = new Student();
            int selectedId = 1;
            _httpTest.RespondWithJson(mockWrapper);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.AddStudent(student, selectedId);

            // Assert
            _httpTest.ShouldHaveCalled($"https://localhost:7236/api/cursusinstanties/{selectedId}/newstudent")
                .WithVerb(HttpMethod.Post)
                .WithRequestJson(student);
            Assert.AreEqual(mockWrapper.GetType(), result.GetType());
        }

        [TestMethod]
        public void AddStudent_InvalidInput_ExpectCursusInstanceDTOWithError()
        {
            // Arrange
            Student student = null;
            int selectedId = 0;
            _httpTest.RespondWith("Error", 500);

            // Act
            CourseInstanceOperationResult result = _cursusInstanceRepo.AddStudent(student, selectedId);

            // Assert
            _httpTest.ShouldHaveCalled("*")
                .WithVerb(HttpMethod.Post);
            Assert.IsTrue(result.Errors.Any());
        }
    }
}