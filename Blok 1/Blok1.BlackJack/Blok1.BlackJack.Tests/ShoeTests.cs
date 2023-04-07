namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class ShoeTests
    {
        [TestMethod]
        public void DrawCard_ResultsARandomCard()
        {
            // Arrange
            var shoe = new Shoe();
            shoe.Shuffle();
            // Act
            Card card = shoe.DrawCard();

            Assert.IsNotNull(card);
        }

        [TestMethod]
        public void DrawCard_ResultsARandomFaceUpCard()
        {
            // Arrange
            var shoe = new Shoe();
            shoe.Shuffle();
            // Act
            Card card = shoe.DrawCard();

            Assert.IsTrue(card.FaceUp);
        }

        [TestMethod]
        public void DrawCard_WithFaceDownIsTrue_ResultsInARandomFaceDownCard()
        {
            // Arrange
            var shoe = new Shoe();
            shoe.Shuffle();
            // Act
            Card card = shoe.DrawCard(true);

            Assert.IsFalse(card.FaceUp);
        }

        [TestMethod]
        public void NewShoe_ResultsInShoeOf312Cards()
        {
            var shoe = new Shoe();
            int cardsContainedInOneDeck = 52;
            int numberOfDecks = 6;
            Assert.AreEqual(numberOfDecks * cardsContainedInOneDeck, shoe.Cards.Count());
        }

        [TestMethod]
        public void NewShoe_ResultsInUnshuffledDeck()
        {
            var shoe = new Shoe();
            CollectionAssert.AreEqual(_spadesDeck, shoe.Cards.Take(13).ToList());
        }

        [TestMethod]
        public void Shuffle_Shoe_ResultsInShuffledShoe()
        {
            var shoe = new Shoe();
            shoe.Shuffle();
            CollectionAssert.AreNotEqual(_spadesDeck, shoe.Cards.Take(13).ToList());
        }

        [TestMethod]
        public void ShuffledShoe_ContainsSameCount_AsUnshuffledShoe()
        {
            // Arrange
            var shoe = new Shoe();
            var unshuffledShoe = new Shoe();

            // Act
            shoe.Shuffle();

            Assert.AreEqual(shoe.Cards.Count(), unshuffledShoe.Cards.Count());
        }

        [TestMethod]
        public void ShuffledShoe_ContainsSameElementsAsUnshuffledShoe()
        {
            // Arrange
            var shoe = new Shoe();
            var unshuffledShoe = new Shoe();

            // Act
            shoe.Shuffle();

            // Assert
            CollectionAssert.AreEquivalent(shoe.Cards.ToList(), unshuffledShoe.Cards.ToList());
        }

        private readonly List<Card> _spadesDeck = new()
        {
            new Card(Suit.Spades, Rank.Ace),
            new Card(Suit.Spades, Rank.King),
            new Card(Suit.Spades, Rank.Queen),
            new Card(Suit.Spades, Rank.Jack),
            new Card(Suit.Spades, Rank.Ten),
            new Card(Suit.Spades, Rank.Nine),
            new Card(Suit.Spades, Rank.Eight),
            new Card(Suit.Spades, Rank.Seven),
            new Card(Suit.Spades, Rank.Six),
            new Card(Suit.Spades, Rank.Five),
            new Card(Suit.Spades, Rank.Four),
            new Card(Suit.Spades, Rank.Three),
            new Card(Suit.Spades, Rank.Two)
        };

        [TestMethod]
        public void MarkerReached_Should_Return_True_When_Marker_Is_Reached()
        {
            // Arrange
            var shoe = new Shoe();
            int numCardsToRemove = 236;
            for (int i = 0; i < numCardsToRemove; i++)
            {
                shoe.DrawCard();
            }

            // Act
            bool markerReached = shoe.MarkerReached;

            // Assert
            Assert.IsTrue(markerReached);
        }

        [TestMethod]
        public void MarkerReached_Should_Return_False_When_Marker_Is_Not_Reached()
        {
            // Arrange
            var shoe = new Shoe();
            int numCardsToRemove = 212;
            for (int i = 0; i < numCardsToRemove; i++)
            {
                shoe.DrawCard();
            }

            // Act
            bool markerReached = shoe.MarkerReached;

            // Assert
            Assert.IsFalse(markerReached);
        }

        [TestMethod]
        public void MarkerReached_Should_Return_True_When_All_Cards_Are_Removed()
        {
            // Arrange
            var shoe = new Shoe();
            var numCardsToRemove = shoe.Cards.Count();
            for (int i = 0; i < numCardsToRemove; i++)
            {
                shoe.DrawCard();
            }

            // Act
            bool markerReached = shoe.MarkerReached;

            // Assert
            Assert.IsTrue(markerReached);
        }
    }
}