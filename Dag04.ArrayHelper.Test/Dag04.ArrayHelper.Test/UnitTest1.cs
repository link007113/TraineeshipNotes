namespace Dag04.ArrayHelper.Test
{
    [TestClass]
    public class ArrayHelperTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] array = new int[0];
            ArrayHelper arrayHelper = new ArrayHelper();

            int som = arrayHelper.SomVanElementen(array);

            Assert.AreEqual(0, som);


        }
    }
}