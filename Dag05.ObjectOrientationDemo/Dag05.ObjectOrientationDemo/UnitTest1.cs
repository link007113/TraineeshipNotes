using ObjectOrientationDemoLibary;
using System.Diagnostics;
using System.Drawing;

namespace Dag05.ObjectOrientationDemo
{
    [TestClass]
    public class ObjectOrientationDemo
    {
        [TestMethod]
        public void Car_SpeedUp_Is_1()
        {
            Car car = new Car("Orange/Black", "GK-188-Z","Renault");

            car.SpeedUp();

            Assert.IsTrue(car.Speed == 1.0);
        }
    }
}