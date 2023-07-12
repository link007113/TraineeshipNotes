using CursusCase.Shared.Helpers;

namespace CursusCase.Shared.Tests.Helpers
{
    [TestClass]
    public class DateCalculatorTests
    {
        [DataTestMethod]
        [DataRow(2023, 1, "2023-01-02")]
        [DataRow(2023, 20, "2023-05-15")]
        public void FirstDateOfWeekISO8601_ValidInput_ReturnsExpectedDate(int year, int weekOfYear, string expectedDateString)
        {
            // Arrange
            DateTime expectedDate = DateTime.Parse(expectedDateString);

            // Act
            DateTime result = DateCalculator.FirstDateOfWeekISO8601(year, weekOfYear);

            // Assert
            Assert.AreEqual(expectedDate, result);
        }

        [DataTestMethod]
        [DataRow(2023, -1)]
        [DataRow(2023, 54)]
        public void FirstDateOfWeekISO8601_InvalidWeekNumber_ThrowsException(int year, int weekOfYear)
        {
            // Arrange, Act & Assert
            Assert.ThrowsException<ArgumentException>(() => DateCalculator.FirstDateOfWeekISO8601(year, weekOfYear));
        }
    }
}