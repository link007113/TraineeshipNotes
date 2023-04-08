using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class RankTests
    {
        [TestMethod]
        public void GetValue_Ace_ResultsIn11()
        {
            var output = Rank.Ace.GetValue();
            Assert.AreEqual(11, output);
        }

        [TestMethod]
        public void GetValue_King_ResultsIn10()
        {
            var output = Rank.King.GetValue();
            Assert.AreEqual(10, output);
        }

        [TestMethod]
        public void GetValue_Queen_ResultsIn11()
        {
            var output = Rank.Queen.GetValue();
            Assert.AreEqual(10, output);
        }

        [TestMethod]
        public void GetValue_Jack_ResultsIn10()
        {
            var output = Rank.Jack.GetValue();
            Assert.AreEqual(10, output);
        }

        [TestMethod]
        public void ToShortString_Ace_ResultsInA()
        {
            var output = Rank.Ace.ToShortString();
            Assert.AreEqual("A", output);
        }

        [TestMethod]
        public void ToShortString_King_ResultsInK()
        {
            var output = Rank.King.ToShortString();
            Assert.AreEqual("K", output);
        }

        [TestMethod]
        public void ToShortString_Two_ResultsIn2()
        {
            var output = Rank.Two.ToShortString();
            Assert.AreEqual("2", output);
        }

        [TestMethod]
        public void ToShortString_AllRanks_ResultsIn2()
        {
            string allCharacters = "AKQJ1098765432";
            string output = string.Empty;
            foreach (Rank item in Enum.GetValues(typeof(Rank)))
            {
                output += item.ToShortString();
            }

            Assert.AreEqual(allCharacters, output);
        }
    }
}