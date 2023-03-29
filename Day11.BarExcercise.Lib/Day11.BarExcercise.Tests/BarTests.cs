using Day11.BarExcercise.Lib;
using System.ComponentModel;

namespace Day11.BarExcercise.Tests
{
    [TestClass]
    public class BarTests
    {
        private Bar bar;

        [TestInitialize]
        public void Setup()
        {
            bar = new Bar();
        }

        [TestMethod]
        public void TakeOrder_AddsOneDrinkToOneTable()
        {
            // Arrange
            int tableNumber = 1;
            string waiterName = "John";
            Drinks drink = Drinks.BeerTap;

            // Act
            bar.TakeOrder(tableNumber, waiterName, drink);

            // Assert
            string bill = bar.AskBill(tableNumber);
            Assert.IsTrue(bill.Contains("1 - BeerTap"));
        }

        [TestMethod]
        public void TakeOrder_AddsOneDrinkToTwoTables()
        {
            // Arrange
            int tableNumber1 = 1;
            int tableNumber2 = 2;
            string waiterName = "John";
            Drinks drinkForTable1 = Drinks.BeerTap;
            Drinks drinkForTable2 = Drinks.Cola;

            // Act
            bar.TakeOrder(tableNumber1, waiterName, drinkForTable1);
            bar.TakeOrder(tableNumber2, waiterName, drinkForTable2);
            // Assert
            string bill = bar.AskBill(tableNumber1);
            Assert.IsTrue(bill.Contains("1 - BeerTap"));

            bill = bar.AskBill(tableNumber2);
            Assert.IsTrue(bill.Contains("1 - Cola"));
        }

        [TestMethod]
        public void TakeOrder_AddsListOfDrinksToTable()
        {
            // Arrange
            int tableNumber = 1;
            string waiterName = "John";
            List<Drinks> drinks = new List<Drinks>();
            drinks.Add(Drinks.Cola);
            drinks.Add(Drinks.BeerBottle);

            // Act
            bar.TakeOrder(tableNumber, waiterName, drinks);

            // Assert
            string bill = bar.AskBill(tableNumber);
            Assert.IsTrue(bill.Contains("1 - Cola"));
            Assert.IsTrue(bill.Contains("1 - BeerBottle"));
        }

        [TestMethod]
        public void TakeOrder_AddsListOfDrinksOfTheSameTypeToTable()
        {
            // Arrange
            int tableNumber = 1;
            string waiterName = "John";
            List<Drinks> drinks = new List<Drinks>();
            drinks.Add(Drinks.Cola);
            drinks.Add(Drinks.BeerBottle);
            drinks.Add(Drinks.BeerBottle);
            // Act
            bar.TakeOrder(tableNumber, waiterName, drinks);

            // Assert
            string bill = bar.AskBill(tableNumber);
            Assert.IsTrue(bill.Contains("1 - Cola"));
            Assert.IsTrue(bill.Contains("2 - BeerBottle"));
        }

        [TestMethod]
        public void AskBill_ContainsAllDrinksAdded()
        {
            // Arrange
            int tableNumber = 1;
            string waiterName = "John";
            List<Drinks> drinks = new List<Drinks>();
            drinks.Add(Drinks.Cola);
            drinks.Add(Drinks.BeerBottle);
            bar.TakeOrder(tableNumber, waiterName, drinks);
            // Act
            string bill = bar.AskBill(tableNumber);

            // Assert
            Assert.IsTrue(bill.Contains("Bill for table 1"));
            Assert.IsTrue(bill.Contains("1 - Cola"));
            Assert.IsTrue(bill.Contains("1 - BeerBottle"));
            Assert.IsTrue(bill.Contains("Total amount:"));
        }

        [TestMethod]
        public void AskBill_WithoutOrder_ResultsInArgumentOutOfRangeException()
        {
            // Arrange
            int tableNumber = 1;

            // Act
            void act()
            {
                string bill = bar.AskBill(tableNumber);
            }
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }

        [TestMethod]
        public void AskBill_PricesAreCorrect_With2ItemsOfDiffrentTypes()
        {
            // Arrange
            int tableNumber = 1;
            string waiterName = "John";
            List<Drinks> drinks = new List<Drinks>();
            drinks.Add(Drinks.Cola);
            drinks.Add(Drinks.BeerBottle);
            bar.TakeOrder(tableNumber, waiterName, drinks);
            // Act
            string bill = bar.AskBill(tableNumber);

            // Assert
            Assert.IsTrue(bill.Contains("2.50"));
            Assert.IsTrue(bill.Contains("4.00"));
            Assert.IsTrue(bill.Contains("6.50"));
        }

        [TestMethod]
        public void AskBill_PricesAreCorrectWith2ItemsOfSameTypeAnd1OfDiffrentType()
        {
            // Arrange
            int tableNumber = 1;
            string waiterName = "John";
            List<Drinks> drinks = new List<Drinks>();
            drinks.Add(Drinks.Cola);
            drinks.Add(Drinks.BeerBottle);
            drinks.Add(Drinks.BeerBottle);
            bar.TakeOrder(tableNumber, waiterName, drinks);
            // Act
            string bill = bar.AskBill(tableNumber);

            // Assert
            Assert.IsTrue(bill.Contains("2.50"));
            Assert.IsTrue(bill.Contains("8.00"));
            Assert.IsTrue(bill.Contains("10.50"));
        }

        [TestMethod]
        public void PayBill_PayExactAmount_NoTipForWaiter()
        {
            // Arrange
            int tableNumber = 1;
            string waiterName = "John";
            Drinks drink = Drinks.BeerTap;
            decimal amountPaid = 3.50m;
            bar.TakeOrder(tableNumber, waiterName, drink);

            // Act
            bar.PayBill(tableNumber, amountPaid);

            // Assert
            Assert.IsTrue(bar.GetWaiterTipSummary(waiterName).Contains("has not earned any tips"));
        }

        [TestMethod]
        public void PayBill_PayLessThanAmount_ResultsInPaymentInsufficientException()
        {
            // Arrange
            int tableNumber = 1;
            string waiterName = "John";
            Drinks drink = Drinks.BeerTap;
            decimal amountPaid = 1.50m;
            bar.TakeOrder(tableNumber, waiterName, drink);

            // Act
            void act()
            {
                bar.PayBill(tableNumber, amountPaid);
            }

            // Assert
            Assert.ThrowsException<PaymentInsufficientException>(act);
        }

        [TestMethod]
        public void PayBill_PayMoreThanAmount_TipForWaiter()
        {
            // Arrange
            int tableNumber = 1;
            string waiterName = "John";
            Drinks drink = Drinks.BeerTap;
            decimal amountPaid = 25m;
            bar.TakeOrder(tableNumber, waiterName, drink);

            // Act
            bar.PayBill(tableNumber, amountPaid);

            // Assert
            Assert.IsTrue(bar.GetWaiterTipSummary(waiterName).Contains("Waiter John earned $21.50"));
        }

        [TestMethod]
        public void PayBill_PayMoreThanAmount_TipForWaiter_AndDivideTipFair()
        {
            // Arrange
            int tableNumber1 = 1;

            string waiterName1 = "John";
            string waiterName2 = "Barry";
            string waiterName3 = "Bob";

            List<Drinks> drinks1 = new List<Drinks>();
            drinks1.Add(Drinks.Cola);
            drinks1.Add(Drinks.BeerBottle);
            drinks1.Add(Drinks.BeerBottle);

            List<Drinks> drinks2 = new List<Drinks>();
            drinks2.Add(Drinks.WineRedBottle);
            drinks2.Add(Drinks.WineRoseBottle);

            List<Drinks> drinks3 = new List<Drinks>();
            drinks3.Add(Drinks.Cassis);
            drinks3.Add(Drinks.Sinas);

            decimal amountPaid1 = 150m;

            bar.TakeOrder(tableNumber1, waiterName1, drinks1);
            bar.TakeOrder(tableNumber1, waiterName2, drinks2);
            bar.TakeOrder(tableNumber1, waiterName3, drinks3);
            bar.TakeOrder(tableNumber1, waiterName1, drinks3);

            string bill1 = bar.AskBill(tableNumber1);

            // Act
            bar.PayBill(tableNumber1, amountPaid1);

            // Assert
            Assert.IsTrue(bar.GetWaiterTipSummary(waiterName1).Contains("Waiter John earned $41.75"));
            Assert.IsTrue(bar.GetWaiterTipSummary(waiterName2).Contains("Waiter Barry earned $20.88"));
            Assert.IsTrue(bar.GetWaiterTipSummary(waiterName3).Contains("Waiter Bob earned $20.88"));
        }

        [TestMethod]
        public void PayBill_WithoutOrder_ResultsInArgumentOutOfRangeException()
        {
            // Arrange
            int tableNumber = 1;
            decimal amount = 1000m;

            // Act
            void act()
            {
                bar.PayBill(tableNumber, amount);
            }
            // Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }
    }
}