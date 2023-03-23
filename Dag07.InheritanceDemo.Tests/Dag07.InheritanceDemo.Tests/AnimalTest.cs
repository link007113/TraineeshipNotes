using Dag07.InheritanceDemo.Lib;

namespace Dag07.InheritanceDemo.Tests
{
    [TestClass]
    public class AnimalTest
    {
        [TestMethod]
        public void Animal_Has_Initial_Weight()
        {
            const double weigth = 4.5;
            Animal animal = new(weigth);
            Assert.IsTrue(animal.Weight == 4.5);
        }

        [TestMethod]
        public void Eat_AnimalWithWeight5_GainsWeight()
        {
            const double weigth = 5;
            Animal animal = new(weigth);
            animal.Eat(0.6);

            Assert.IsTrue(animal.Weight == 5.6);
        }
    }
}