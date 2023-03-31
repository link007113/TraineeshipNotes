namespace Day14.LinqExcercise.Tests
{
    [TestClass]
    public class NameTests
    {
        [TestMethod]
        public void CountFromList_ResultsIn9()
        {
            // Arrange
            var nameList = new NameList();

            // Act
            int count = nameList.CountFromList();

            // Assert
            Assert.AreEqual(9, count);
        }

        [TestMethod]
        public void CountFromListComprehensionContainsA_ResultsIn7()
        {
            // Arrange
            var nameList = new NameList();

            // Act
            int count = nameList.CountFromListComprehensionContainsA();

            // Assert
            Assert.AreEqual(7, count);
        }

        [TestMethod]
        public void CountFromListExtensionMethodContainsA_ResultsIn7()
        {
            // Arrange
            var nameList = new NameList();

            // Act
            int count = nameList.CountFromListExtensionMethodContainsA();

            // Assert
            Assert.AreEqual(7, count);
        }

        [TestMethod]
        public void AllFirstLettersFromListComprehensionContainsA_ResultsInY()
        {
            // Arrange
            var nameList = new NameList();

            // Act
            char[] letters = nameList.AllFirstLettersFromListComprehensionContainsA();

            // Assert
            Assert.AreEqual('Y', letters.First());
        }

        [TestMethod]
        public void AllFirstLettersFromListExtensionMethodStartsWithA_ResultsInY()
        {
            // Arrange
            var nameList = new NameList();

            // Act
            char[] letters = nameList.AllFirstLettersFromListExtensionMethodStartsWithA();

            // Assert
            Assert.AreEqual('Y', letters.First());
        }

        [TestMethod]
        public void SumOfAllNamesContainingYComprehensionContains_ResultsIn20()
        {
            // Arrange
            var nameList = new NameList();

            // Act
            int sum = nameList.SumOfAllNamesContainingYComprehensionContains();

            // Assert
            Assert.AreEqual(20, sum);
        }

        [TestMethod]
        public void SumOfAllNamesContainingYExtensionMethodContains_ResultsIn20()
        {
            // Arrange
            var nameList = new NameList();

            // Act
            int sum = nameList.SumOfAllNamesContainingYExtensionMethodContains();

            // Assert
            Assert.AreEqual(20, sum);
        }

        [TestMethod]
        public void NamesWithAverageLengthComprehension_Results()
        {
            // Arrange
            var nameList = new NameList();

            // Act
            List<string> names = nameList.NamesWithAverageLengthComprehension();

            // Assert
            Assert.AreEqual(6, names.Count);
        }

        [TestMethod]
        public void NamesWithAverageLengthExtensionMethod_Results()
        {
            // Arrange
            var nameList = new NameList();

            // Act
            List<string> names = nameList.NamesWithAverageLengthExtensionMethod();

            // Assert
            Assert.AreEqual(6, names.Count);
        }
    }
}