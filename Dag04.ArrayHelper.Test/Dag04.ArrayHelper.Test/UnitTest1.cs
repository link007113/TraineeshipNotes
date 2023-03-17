namespace Dag04.ArrayHelper.Test
{
    [TestClass]
    public class ArrayHelperTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] array = new int[2]
                {
                    1,
                    2
                };
            ArrayHelper arrayHelper = new ArrayHelper();

            int som = arrayHelper.SomVanElementen(array);

            Assert.AreEqual(3, som);
        }
    }
}