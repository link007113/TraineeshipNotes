using Dag06.StructDemoLibrary;

namespace Dag06.StructDemoTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Main()
        {
            Time time = new(3,15);
            Console.WriteLine($"H:{time.Hours} M:{time.Minutes} uur");

            Time time1 = time.AddMinutes(50);
            Console.WriteLine($"H:{time1.Hours} M:{time1.Minutes} uur");

            Time time2 = (Time)3.5;
        }
    }
}