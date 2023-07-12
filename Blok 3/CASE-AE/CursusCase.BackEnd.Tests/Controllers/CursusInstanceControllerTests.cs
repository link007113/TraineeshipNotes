using CursusCase.Backend.Controllers;
using CursusCase.Shared.Models;
using CursusCase.Shared.Repositories;
using CursusCase.Shared.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CursusCase.BackEnd.Tests.Controllers
{
    [TestClass]
    public class CursusInstanceControllerTestsExtra
    {
        private CursusInstanceController _controller;
        private Mock<ICursusInstanceRepo> _mockRepo;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockRepo = new Mock<ICursusInstanceRepo>();
            _controller = new CursusInstanceController(_mockRepo.Object);
        }

        [TestMethod]
        public void GetAllCursusInstances_ReturnsOk()
        {
            // Arrange
            _mockRepo.Setup(x => x.GetAllInstances()).Returns(new CourseInstanceOperationResult());

            // Act
            IActionResult result = _controller.GetAllCursusInstances();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetAllCursusInstancesFromTillToDate_ReturnsOk()
        {
            // Arrange
            _mockRepo
                .Setup(x => x.GetInstancesBySearchPerWeekAndYear(It.IsAny<int>(), It.IsAny<int>()))
                .Returns(new CourseInstanceOperationResult());

            // Act
            IActionResult result = _controller.GetAllCursusInstancesFromTillToDate(2023, 25);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetInstancesBySearchPerPeriod_ReturnsOk()
        {
            // Arrange
            _mockRepo
                .Setup(
                    x => x.GetInstancesBySearchPerPeriod(It.IsAny<DateTime>(), It.IsAny<DateTime>())
                )
                .Returns(new CourseInstanceOperationResult());

            // Act
            IActionResult result = _controller.GetInstancesBySearchPerPeriod(
                new Period { DateFrom = DateTime.Now, DateTo = DateTime.Now.AddDays(7) }
            );

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void GetCursusInstanceById_ReturnsOk()
        {
            // Arrange
            _mockRepo
                .Setup(x => x.GetCursusInstanceById(It.IsAny<int>()))
                .Returns(new CourseInstanceOperationResult());

            // Act
            IActionResult result = _controller.GetCursusInstanceById(1);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void AddStudentToInstance_ReturnsOk()
        {
            // Arrange
            _mockRepo
                .Setup(x => x.AddStudent(It.IsAny<Student>(), It.IsAny<int>()))
                .Returns(new CourseInstanceOperationResult());

            // Act
            IActionResult result = _controller.AddStudentToInstance(1, new Student());

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void AddCursusInstances_ReturnsResult()
        {
            // Arrange
            _mockRepo
                .Setup(x => x.AddInstances(It.IsAny<List<CourseInstance>>()))
                .Returns(new CourseInstanceOperationResult());

            // Act
            CourseInstanceOperationResult result = _controller.AddCursusInstances(new List<CourseInstance>());

            // Assert
            Assert.IsInstanceOfType(result, typeof(CourseInstanceOperationResult));
        }
    }
}