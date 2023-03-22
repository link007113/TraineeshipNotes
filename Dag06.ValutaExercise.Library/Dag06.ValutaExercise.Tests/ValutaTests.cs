using Dag06.ValutaExercise.Library;

namespace Dag06.ValutaExercise.Tests
{
    [TestClass]
    public class ValutaTests
    {
        [TestMethod]
        public void Given_ValutaEuro_Then_ValutaIsValid()
        {
            ValutaEnum euro = ValutaEnum.Euro;
            bool output = ValutaExtensions.IsValutaValidInTheNetherlands(euro);
            Assert.AreEqual(true, output);

        }

        [TestMethod]
        public void Given_ValutaFlorijn_Then_ValutaIsInvalid()
        {
            ValutaEnum euro = ValutaEnum.Florijn;
            bool output = ValutaExtensions.IsValutaValidInTheNetherlands(euro);
            Assert.AreEqual(false, output);

        }

        [TestMethod]
        public void Given_ValutaGulden_Then_OutputWillBeHfl()
        {
            ValutaEnum gulden = ValutaEnum.Gulden;
            string output = gulden.Code();
            Assert.AreEqual("Hfl", output);
        }

        [TestMethod]
        public void Given_StringEur_Then_OutputWillBeEuroValuta()
        {
            string input = "EUR";
            ValutaEnum output = input.ToValuta();
            Assert.AreEqual(ValutaEnum.Euro, output);
        }

        [TestMethod]
        public void Given_StringAAA_Then_OutputWillBeEuroValuta()
        {
            string input = "AAA";
            void act()
            {
                ValutaEnum output = input.ToValuta();
            }


            var ex = Assert.ThrowsException<InvalidValutaException>(act);

            Assert.IsTrue(ex.Message.StartsWith("This Valuta does"));
        }

        [TestMethod]
        public void Given_ValutaStructGulden10_Then_OutputWillBeEuro454()
        {
            ValutaStruct input = new(ValutaEnum.Gulden, 10.00M);
            ValutaStruct output = input.ConvertTo(ValutaEnum.Euro);
            Assert.AreEqual(4.54M, output.Amount, 2);
            
        }

        [TestMethod]
        public void Given_ValutaStructGulden10_Then_OutputWillString()
        {
            ValutaStruct input = new(ValutaEnum.Gulden, 10.00M);
            string output = input.ToString();
            Assert.AreEqual("Gulden: 10.00", output);

        }

        [TestMethod]
        public void Given_ValutaStructGuldenAndFlorijn_Then_OutputWillBeFlorijn20()
        {
            ValutaStruct input1 = new(ValutaEnum.Gulden, 10.00M);
            ValutaStruct input2 = new(ValutaEnum.Florijn, 10.00M);
            ValutaStruct output = input1 + input2;
            Assert.AreEqual(20M, output.Amount, 2);

        }

        [TestMethod]
        public void Given_Decimal20_Then_OutputWillBeValutaStructEuro20()
        {
            decimal input = 20M; 
            ValutaStruct output = (ValutaStruct)input;
            Assert.AreEqual(20M, output.Amount, 2);

        }

        [TestMethod]
        public void Given_ValutaStructEuro20_Then_OutputWillBeDecimal20()
        {
            ValutaStruct input = new(ValutaEnum.Euro, 20M);
           decimal output = (decimal)input;
            Assert.AreEqual(20M, output, 2);

        }


    }
}