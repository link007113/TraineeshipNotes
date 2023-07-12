using CursusCase.FrontEnd.Pages;
using CursusCase.Shared.Models;
using CursusCase.Shared.Repositories;
using CursusCase.Shared.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Globalization;

namespace CursusCase.FrontEnd.Tests.Pages
{
    [TestClass]
    public class PlanningModelTests
    {
        private Mock<ICursusInstanceRepo> _cursusInstanceRepoMock;
        private PlanningModel _model;

        [TestInitialize]
        public void Setup()
        {
            _cursusInstanceRepoMock = new Mock<ICursusInstanceRepo>();
            _model = new PlanningModel(_cursusInstanceRepoMock.Object);
        }

        [TestMethod]
        public void OnGet_WithValidYearAndWeek_LoadsCursusInstancesForWeekInYear()
        {
            // Arrange
            int year = 2023;
            int week = 25;
            CourseInstanceOperationResult expectedResult = new CourseInstanceOperationResult
            {
                CursusInstances = new List<CourseInstance> { new CourseInstance() }
            };
            _cursusInstanceRepoMock.Setup(r => r.GetInstancesBySearchPerWeekAndYear(year, week))
                .Returns(expectedResult);

            // Act
            _model.OnGet(year, week);

            // Assert
            CollectionAssert.AreEqual(expectedResult.CursusInstances.ToList(), _model.CursusInstances.ToList());
            Assert.IsTrue(_model.Errors.Count == 0);
            _cursusInstanceRepoMock.Verify(r => r.GetInstancesBySearchPerWeekAndYear(year, week), Times.Once);
        }

        [TestMethod]
        public void OnGet_WithInvalidYearAndWeek_UsesDefaultWeekAndYear_LoadsCursusInstancesForWeekInYear()
        {
            // Arrange
            int defaultYear = DateTime.Now.Year;
            int defaultWeek = ISOWeek.GetWeekOfYear(DateTime.Now);
            CourseInstanceOperationResult expectedResult = new CourseInstanceOperationResult
            {
                CursusInstances = new List<CourseInstance> { new CourseInstance() }
            };
            _cursusInstanceRepoMock.Setup(r => r.GetInstancesBySearchPerWeekAndYear(defaultYear, defaultWeek))
                .Returns(expectedResult);

            // Act
            _model.OnGet(0, 0);

            // Assert
            CollectionAssert.AreEqual(expectedResult.CursusInstances.ToList(), _model.CursusInstances.ToList());
            Assert.IsTrue(_model.Errors.Count == 0);
            _cursusInstanceRepoMock.Verify(r => r.GetInstancesBySearchPerWeekAndYear(defaultYear, defaultWeek), Times.Once);
        }

        [TestMethod]
        public void OnPostSearchPerWeekAndYear_RedirectsToPlanningPageWithYearAndWeek()
        {
            // Arrange
            int year = 2023;
            int week = 25;

            // Act
            IActionResult result = _model.OnPostSearchPerWeekAndYear(year, week);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RedirectToPageResult));
            RedirectToPageResult redirectToPageResult = (RedirectToPageResult)result;

            Assert.AreEqual("/Planning", ((RedirectToPageResult)result).PageName);
            Assert.AreEqual(year, ((RedirectToPageResult)result).RouteValues["year"]);
            Assert.AreEqual(week, ((RedirectToPageResult)result).RouteValues["week"]);
        }

        [TestMethod]
        public void OnPostSearchPerDateRange_LoadsCursusInstancesForPeriod()
        {
            // Arrange
            DateTime dateFrom = new DateTime(2023, 6, 1);
            DateTime dateTo = new DateTime(2023, 6, 7);
            CourseInstanceOperationResult expectedResult = new CourseInstanceOperationResult
            {
                CursusInstances = new List<CourseInstance> { new CourseInstance() }
            };
            _cursusInstanceRepoMock.Setup(r => r.GetInstancesBySearchPerPeriod(dateFrom, dateTo))
                .Returns(expectedResult);

            // Act
            _model.OnPostSearchPerDateRange(dateFrom, dateTo);

            // Assert
            CollectionAssert.AreEqual(expectedResult.CursusInstances.ToList(), _model.CursusInstances.ToList());
            Assert.IsTrue(_model.Errors.Count == 0);
            _cursusInstanceRepoMock.Verify(r => r.GetInstancesBySearchPerPeriod(dateFrom, dateTo), Times.Once);
        }
    }
}