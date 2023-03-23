using Dag08.InterfaceExcersice.Lib;

namespace Dag08.InterfaceExcersice.Tests
{
    [TestClass]
    public class ShapeTest
    {
        [TestMethod]
        public void CalculateVolume_For_Diffent_IShapes_Result_In_15()
        {
            IShape[] shapes = { new Bar(10, 2, 15), new Sphere(15), new Cube(5) };

            var volume = shapes.Sum(s => s.CalculateVolume());

            Assert.AreEqual(15, volume);
        }
    }
}