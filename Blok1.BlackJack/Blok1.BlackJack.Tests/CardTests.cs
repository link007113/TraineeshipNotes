using Blok1.BlackJack.Enums;
using Blok1.BlackJack.Classes;

namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void NewCardOfTenGivesCardValueOf10()
        {
            var card = new Card(Suit.Clubs, Rank.Ten);
            Assert.AreEqual(10, card.Value);
        }

        [TestMethod]
        public void NewCardOfAceGivesCardValueOf11()
        {
            var card = new Card(Suit.Clubs, Rank.Ace);
            Assert.AreEqual(11, card.Value);
        }

        [TestMethod]
        public void NewDefaultCardIsVisible()
        {
            var card = new Card(Suit.Clubs, Rank.Two);
            Assert.IsTrue(card.Visible);
        }

        [TestMethod]
        public void NewNonVisibleCardIsInVisible()
        {
            var card = new Card(Suit.Clubs, Rank.Two, false);
            Assert.IsFalse(card.Visible);
        }
    }
}