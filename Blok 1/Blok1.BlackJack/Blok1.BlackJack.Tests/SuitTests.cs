using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class SuitTests
    {
        [TestMethod]
        public void ToCharacter_Spades_ResultInCharacter()
        {
            var output = Suit.Spades.ToCharacter();
            Assert.AreEqual("♠", output);
        }

        [TestMethod]
        public void ToCharacter_Hearts_ResultInCharacter()
        {
            var output = Suit.Hearts.ToCharacter();
            Assert.AreEqual("♥", output);
        }

        [TestMethod]
        public void ToCharacter_Diamonds_ResultInCharacter()
        {
            var output = Suit.Diamonds.ToCharacter();
            Assert.AreEqual("♦", output);
        }

        [TestMethod]
        public void ToCharacter_Clubs_ResultInCharacter()
        {
            var output = Suit.Clubs.ToCharacter();
            Assert.AreEqual("♣", output);
        }
    }
}