using Dag06.ValutaExercise.Library;

namespace Dag06.ValutaExercise.Tests
{
    [TestClass]
    public class ValutaTests
    {
        [TestMethod]
        public void Given_ValutaEuro_Then_ValutaIsValid()
        {
            Valuta euro = Valuta.Euro;
            bool output = IsValutaValidInTheNetherlands(euro);
            Assert.AreEqual(true, output);

        }

        [TestMethod]
        public void Given_ValutaFlorijn_Then_ValutaIsInvalid()
        {
            Valuta euro = Valuta.Florijn;
            bool output = IsValutaValidInTheNetherlands(euro);
            Assert.AreEqual(false, output);

        }

        [TestMethod]
        public void Given_ValutaGulden_Then_OutputWillBeHfl()
        {
            Valuta gulden = Valuta.Gulden;
            string output = gulden.Code();
            Assert.AreEqual("Hfl", output);
        }

        [TestMethod]
        public void Given_StringEur_Then_OutputWillBeEuroValuta()
        {
            string input = "EUR";
            Valuta output = input.ToValuta();
            Assert.AreEqual(Valuta.Euro, output);
        }

        [TestMethod]
        public void Given_StringAAA_Then_OutputWillBeEuroValuta()
        {
            string input = "AAA";
            void act()
            {
                Valuta output = input.ToValuta();
            }


            var ex = Assert.ThrowsException<InvalidValutaException>(act);

            Assert.IsTrue(ex.Message.StartsWith("This Valuta does"));
        }


        public static bool IsValutaValidInTheNetherlands(Valuta valuta) => valuta switch
        {
            Valuta.Dukaat => false,
            Valuta.Gulden => false,
            Valuta.Florijn => false,
            Valuta.Euro => true

        };
    }
}