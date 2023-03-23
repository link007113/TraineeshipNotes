using Dag07.InheritanceDemo.Lib;

namespace Dag07.InheritanceDemo.Tests
{
    [TestClass]
    public class BirdTest
    {
        private Bird _sut = null!;

        [TestInitialize]
        public void TestIntialize()
        {
            _sut = new Bird(0.2);
        }

        [TestMethod]
        public void Bird_Has_Initial_Weight()
        {
            Assert.IsTrue(_sut.Weight == 0.2);
        }

        [TestMethod]
        public void Eat_BirdWithWeight02_GainsWeight()
        {
            _sut.Eat(0.6);
            Assert.IsTrue(_sut.Weight == 0.8);
        }
    }
}