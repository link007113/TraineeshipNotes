using Blok1.BlackJack.Enums;
using Blok1.BlackJack.Classes;

namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void NewHandHasZeroTotalValue()
        {
            var hand = new Hand();
            Assert.AreEqual(0, hand.TotalValue);
        }

        [TestMethod]
        public void NewHandWithOneCardHasTotalValueOfThatCard()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            Assert.AreEqual(10, hand.TotalValue);
        }

        [TestMethod]
        public void NewHandWithTwoCardsHasTotalValueOfThoseCards()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            hand.AddCard(new Card(Suit.Clubs, Rank.Two));
            Assert.AreEqual(12, hand.TotalValue);
        }

        [TestMethod]
        public void NewHandHasABetOfZero()
        {
            var hand = new Hand();
            Assert.AreEqual(0, hand.Bet);
        }

        [TestMethod]
        public void NewHandGetsCardsResultInBlackJack()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            Assert.IsTrue(hand.IsBlackJack);
        }

        [TestMethod]
        public void NewHandGetsCardsResultInNotBlackJack()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            hand.AddCard(new Card(Suit.Clubs, Rank.Nine));
            Assert.IsFalse(hand.IsBlackJack);
        }

        [TestMethod]
        public void NewHandHasBetOf10AfterPlaceBetOf10()
        {
            var hand = new Hand();
            hand.PlaceBet(10);
            Assert.AreEqual(10, hand.Bet);
        }

        [TestMethod]
        public void NewHandGetsCardsResultInCanSplit()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            hand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            Assert.IsTrue(hand.CanSplit);
        }

        [TestMethod]
        public void NewHandGetsCardsResultInIsBust()
        {
            var hand = new Hand();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            Assert.IsTrue(hand.IsBust);
        }
    }
}