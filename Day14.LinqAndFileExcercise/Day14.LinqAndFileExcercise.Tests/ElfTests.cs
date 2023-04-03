namespace Day14.LinqAndFileExcercise.Tests
{
    [TestClass]
    public class ElfTests
    {
        [TestMethod]
        public void GetAllElves_ResultInFilledList()
        {
            List<Elf> elves = Elf.GetAllElves();

            Assert.AreEqual(247, elves.Count);
        }

        [TestMethod]
        public void GetAllElves_ResultInFilledListWithFoodItems()
        {
            List<Elf> elves = Elf.GetAllElves();
            Assert.IsTrue(elves[0].FoodItems.Count != 0);
        }

        [TestMethod]
        public void GetMaxAmountOfCalories_ResultsInMaxAmountIs66719()
        {
            // Arrange
            List<Elf> elves = Elf.GetAllElves();

            // Act
            int maxCalories = Elf.GetMaxAmountOfCalories(elves);

            // Assert
            Assert.AreEqual(66719, maxCalories);
        }

        [TestMethod]
        public void GetMaxAmountOfTop3ElvesCalories_ResultsInMaxAmountIs66719()
        {
            // Arrange
            List<Elf> elves = Elf.GetAllElves();

            // Act
            int maxCalories = Elf.GetMaxAmountOfTop3ElvesCalories(elves);

            // Assert
            Assert.AreEqual(198551, maxCalories);
        }
    }
}