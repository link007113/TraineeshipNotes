using Blok1.BlackJack.Enums;
using Blok1.BlackJack.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class ShoeTests
    {
        [TestMethod]
        public void NewShoeResultsInShoeOf312Cards()
        {
            var shoe = new Shoe();
            Assert.AreEqual(312, shoe.Cards.Count);
        }

        [TestMethod]
        public void NewShoeResultsInUnshuffledDeck()
        {
            var shoe = new Shoe();
            Assert.AreEqual(new Card(Suit.Spades, Rank.Ace), shoe.Cards[0]);
        }

        [TestMethod]
        public void NewShoeResultsInShuffledDeck()
        {
            var shoe = new Shoe();
            shoe.Shuffle();
            Assert.AreNotEqual(new Card(Suit.Spades, Rank.Ace), shoe.Cards[0]);
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

            foreach (var card in shoe.Cards)
            {
                Assert.IsTrue(unshuffledShoe.Cards.Contains(card));
            }
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