using Dag10.Delegate.Lib;

namespace Dag10.Delegate.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            Formateerder formateerder = Layout.LieftinckFormaat;
            // Act
            string output = Printer.Print(36, formateerder);
            // Assert
            Assert.AreEqual("Het getal is [36]", output);
        }
    }
}