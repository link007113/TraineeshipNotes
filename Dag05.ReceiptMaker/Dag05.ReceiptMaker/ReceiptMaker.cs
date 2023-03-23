using ReceiptMakerLibrary;

namespace Dag05.ReceiptMaker
{
    [TestClass]
    public class ReceiptMaker
    {
        [TestMethod]
        public void AddItemsToReceiptAndCheckTotalPrice()
        {
            Receipt receipt = new Receipt();
            receipt.Scan("Melk", 1.15M);
            receipt.Scan("Melk", 1.15M);
            receipt.Scan("Appel", 2M);
            receipt.Scan("Kaas", 5M);

            string receiptPrint = receipt.ToString();
            Console.WriteLine(receiptPrint);

            Assert.IsTrue(receipt.TotalPrice == 9.3M);
        }

        [TestMethod]
        public void TooManyItemsToReceiptAndAssertException()
        {
            Receipt receipt = new Receipt();

            void act()
            {
                receipt.Scan("Melk", 1.15M);
                receipt.Scan("Melk", 1.15M);
                receipt.Scan("Appel", 2M);
                receipt.Scan("Kaas", 5M);
                receipt.Scan("Ham", 1.15M);
                receipt.Scan("Spek", 1.15M);
                receipt.Scan("Salami", 2M);
                receipt.Scan("Pepperoni", 5M);
                receipt.Scan("Sla", 1.15M);
                receipt.Scan("Ui", 1.15M);
                receipt.Scan("Kant en klaar stampot", 2M);
                receipt.Scan("Kaas", 5M);
                receipt.Scan("Melk", 1.15M);
                receipt.Scan("Melk", 1.15M);
                receipt.Scan("Appel", 2M);
                receipt.Scan("Kaas", 5M);
                receipt.Scan("Melk", 1.15M);
                receipt.Scan("Pannenkoek", 1.15M);
                receipt.Scan("Appel", 2M);
                receipt.Scan("Kaas", 5M);
            }

           var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(act);
            Assert.IsTrue(ex.Message.StartsWith("Receipt doesn't have space"));
        }


        [TestMethod]
        public void TestAutoGenerateReceiptNr()
        {
            Receipt receipt = new Receipt();
            receipt.Scan("Appel", 2M);
            receipt.Scan("Kaas", 5M);
            receipt.Scan("Ham", 1.15M);
            receipt.Scan("Spek", 1.15M);

            Receipt receipt2 = new Receipt();
            receipt2.Scan("Appel", 2M);
            receipt2.Scan("Kaas", 5M);
            receipt2.Scan("Ham", 1.15M);
            receipt2.Scan("Spek", 1.15M);

            Assert.AreEqual(2, receipt.ReceiptNr);
            Assert.AreEqual(3, receipt2.ReceiptNr);
        }
    }
}