namespace Dag04.ArrayHelper.Test
{
    [TestClass]
    public class ArrayHelperTest
    {
        [TestMethod]
        public void SumOfZero()
        {
            // Arrange
            int[] array = new int[0];

            // Act
            ArrayHelper arrayHelper = new ArrayHelper();

            int som = arrayHelper.SomVanElementen(array);


            // Assert
            Assert.AreEqual(0, som);
        }
        [TestMethod]
        public void SumOfOneAndTwo()
        {
            // Arrange
            int[] array = new int[2]
                {
                    1,
                    2
                };

            // Act
            ArrayHelper arrayHelper = new ArrayHelper();

            int som = arrayHelper.SomVanElementen(array);


            // Assert
            Assert.AreEqual(3, som);
        }
    }
}