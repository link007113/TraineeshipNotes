using Dag05.VolumeExerciseLibrary;

namespace Dag05.VolumeExerciseTests
{
    [TestClass]
    public class VolumeExerciseTests
    {
        [TestMethod]
        public void TestBarCalculateVolume()
        {
            double height = 10;
            double width = 15.5;
            double length = 20;

            Bar bar = new Bar(height,width,length);

            var output = bar.CalculateVolume();

            Assert.IsTrue(output == 3100);
            
        }

        [TestMethod]
        public void TestSphereCalculateVolume() 
        { 
            Sphere sphere = new Sphere(15);
            var output = sphere.CalculateVolume();

            Assert.IsTrue(output == 14137.166941154068);

        }

        [TestMethod]
        public void TestBarCalculateSurface()
        {
            double height = 10;
            double width = 15.5;
            double length = 20;

            Bar bar = new Bar(height, width, length);

            var output = bar.CalculateSurface();

            Assert.IsTrue(output == 1100);

        }

        [TestMethod]
        public void TestSphereCalculateSurface()
        {
            Sphere sphere = new Sphere(15);
            var output = sphere.CalculateSurface();

            Assert.IsTrue(output == 2827.4333882308138);

        }
    }
}