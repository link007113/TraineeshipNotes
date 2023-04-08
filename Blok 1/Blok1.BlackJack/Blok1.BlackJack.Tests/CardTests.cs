using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void FaceUp_ShouldBeFalse_ForNewNonVisibleCard()
        {
            var card = new Card(Suit.Clubs, Rank.Two, false);
            Assert.IsFalse(card.FaceUp);
        }

        [TestMethod]
        public void FaceUp_ShouldBeTrue_ForNewDefaultCard()
        {
            var card = new Card(Suit.Clubs, Rank.Two);
            Assert.IsTrue(card.FaceUp);
        }

        [TestMethod]
        public void Flip_ShouldFlipFaceDownToFaceUp()
        {
            // Arrange
            var card = new Card(Suit.Diamonds, Rank.King, false);

            // Act
            card.Flip();

            // Assert
            Assert.IsTrue(card.FaceUp);
        }

        [TestMethod]
        public void Flip_ShouldFlipFaceUpToFaceDown()
        {
            // Arrange
            var card = new Card(Suit.Clubs, Rank.Ace);

            // Act
            card.Flip();

            // Assert
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
            Assert.AreEqual("♠ King of Spades", result);
        }

        [TestMethod]
        public void Value_ShouldReturn10_ForNewCardOfJack()
        {
            var card = new Card(Suit.Clubs, Rank.Jack);
            Assert.AreEqual(10, card.Value);
        }

        [TestMethod]
        public void Value_ShouldReturn10_ForNewCardOfKing()
        {
            var card = new Card(Suit.Clubs, Rank.King);
            Assert.AreEqual(10, card.Value);
        }

        [TestMethod]
        public void Value_ShouldReturn10_ForNewCardOfQueen()
        {
            var card = new Card(Suit.Clubs, Rank.Queen);
            Assert.AreEqual(10, card.Value);
        }

        [TestMethod]
        public void Value_ShouldReturn10_ForNewCardOfTen()
        {
            var card = new Card(Suit.Clubs, Rank.Ten);
            Assert.AreEqual(10, card.Value);
        }

        [TestMethod]
        public void Value_ShouldReturn11_ForNewCardOfAce()
        {
            var card = new Card(Suit.Clubs, Rank.Ace);
            Assert.AreEqual(11, card.Value);
        }
    }
}