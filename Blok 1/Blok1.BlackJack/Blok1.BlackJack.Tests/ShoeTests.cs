namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class ShoeTests
    {
        private List<Card> _spadesDeck = new List<Card>()
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

        [TestInitialize]
        public void TestInitialize()
        {
        }

        [TestMethod]
        public void NewShoeResultsInShoeOf312Cards()
        {
            var shoe = new Shoe();
            int cardsContainedInOneDeck = 52;
            int numberOfDecks = 6;
            Assert.AreEqual(numberOfDecks * cardsContainedInOneDeck, shoe.Cards.Count);
        }

        [TestMethod]
        public void NewShoeResultsInUnshuffledDeck()
        {
            var shoe = new Shoe();
            CollectionAssert.AreEqual(_spadesDeck, shoe.Cards.Take(13).ToList());
        }

        [TestMethod]
        public void NewShoeResultsInShuffledDeck()
        {
            var shoe = new Shoe();
            shoe.Shuffle();
            CollectionAssert.AreNotEqual(_spadesDeck, shoe.Cards.Take(13).ToList());
        }

        [TestMethod]
        public void NewShoeContainsSameCountAsUnshuffledShoe()
        {
            // Arrange
            var shoe = new Shoe();
            var unshuffledShoe = new Shoe();

            // Act
            shoe.Shuffle();

            Assert.AreEqual(shoe.Cards.Count, unshuffledShoe.Cards.Count);
        }

        [TestMethod]
        public void NewShoeContainsSameElementsAsUnshuffledShoe()
        {
            // Arrange
            var shoe = new Shoe();
            var unshuffledShoe = new Shoe();

            // Act
            shoe.Shuffle();
        }

        [TestMethod]
        public void NewShuffeledShoeGivesCardResultsInRandomCard()
        {
            // Arrange
            var shoe = new Shoe();
            shoe.Shuffle();
            // Act
            Card card = shoe.DrawCard();

            Assert.IsNotNull(card);
        }
    }
}