using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void NewCardOfAceGivesCardValueOf11()
        {
            var card = new Card(Suit.Clubs, Rank.Ace);
            Assert.AreEqual(11, card.Value);
        }

        [TestMethod]
        public void NewCardOfJackGivesCardValueOf10()
        {
            var card = new Card(Suit.Clubs, Rank.Jack);
            Assert.AreEqual(10, card.Value);
        }

        [TestMethod]
        public void NewCardOfKingGivesCardValueOf10()
        {
            var card = new Card(Suit.Clubs, Rank.King);
            Assert.AreEqual(10, card.Value);
        }

        [TestMethod]
        public void NewCardOfQueenGivesCardValueOf10()
        {
            var card = new Card(Suit.Clubs, Rank.Queen);
            Assert.AreEqual(10, card.Value);
        }

        [TestMethod]
        public void NewCardOfTenGivesCardValueOf10()
        {
            var card = new Card(Suit.Clubs, Rank.Ten);
            Assert.AreEqual(10, card.Value);
        }

        [TestMethod]
        public void NewDefaultCardIsVisible()
        {
            var card = new Card(Suit.Clubs, Rank.Two);
            Assert.IsTrue(card.FaceUp);
        }

        [TestMethod]
        public void NewNonVisibleCardIsInVisible()
        {
            var card = new Card(Suit.Clubs, Rank.Two, false);
            Assert.IsFalse(card.FaceUp);
        }

        [TestMethod]
        public void ToString_WhenFaceDown_ReturnsCorrectString()
        {
            // Arrange
            var card = new Card(Suit.Spades, Rank.King, false);

            // Act
            var result = card.ToString();

            // Assert
            Assert.AreEqual("## Face Down ##", result);
        }

        [TestMethod]
        public void ToString_WhenFaceUp_ReturnsCorrectString()
        {
            // Arrange
            var card = new Card(Suit.Spades, Rank.King);

            // Act
            var result = card.ToString();

            // Assert
            Assert.AreEqual("King of Spades", result);
        }
    }
}