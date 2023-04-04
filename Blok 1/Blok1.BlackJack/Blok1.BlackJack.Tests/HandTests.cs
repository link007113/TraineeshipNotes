namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void HandWithAceAndKingAndTineGives21Instead31()
        {
            var hand = new HandPlayer();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            hand.AddCard(new Card(Suit.Clubs, Rank.King));
            hand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            Assert.AreEqual(21, hand.TotalValue);
        }

        [TestMethod]
        public void NewHandGetsCardsResultInBlackJack()
        {
            var hand = new HandPlayer();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            Assert.IsTrue(hand.IsBlackJack);
        }

        [TestMethod]
        public void NewHandGetsCardsResultInIsBust()
        {
            var hand = new HandPlayer();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            hand.AddCard(new Card(Suit.Clubs, Rank.King));
            hand.AddCard(new Card(Suit.Clubs, Rank.Queen));
            Assert.IsTrue(hand.IsBust);
        }

        [TestMethod]
        public void NewHandGetsCardsResultInNotBlackJack()
        {
            var hand = new HandPlayer();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            hand.AddCard(new Card(Suit.Clubs, Rank.Nine));
            Assert.IsFalse(hand.IsBlackJack);
        }

        [TestMethod]
        public void NewHandHasABetOfZero()
        {
            var hand = new HandPlayer();
            Assert.AreEqual(0, hand.Bet);
        }

        [TestMethod]
        public void NewHandHasBetOf10AfterPlaceBetOf10()
        {
            var hand = new HandPlayer();
            hand.PlaceBet(10);
            Assert.AreEqual(10, hand.Bet);
        }

        [TestMethod]
        public void NewHandHasZeroTotalValue()
        {
            var hand = new HandPlayer();
            Assert.AreEqual(0, hand.TotalValue);
        }

        [TestMethod]
        public void NewHandWithOneCardHasTotalValueOfThatCard()
        {
            var hand = new HandPlayer();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            Assert.AreEqual(10, hand.TotalValue);
        }

        [TestMethod]
        public void NewHandWithTwoCardsHasTotalValueOfThoseCards()
        {
            var hand = new HandPlayer();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            hand.AddCard(new Card(Suit.Clubs, Rank.Two));
            Assert.AreEqual(12, hand.TotalValue);
        }

        [TestMethod]
        public void NewHandWithTwoDiffrentCardsWithSameValueResultInCanSplit()
        {
            var hand = new HandPlayer();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            hand.AddCard(new Card(Suit.Clubs, Rank.King));
            Assert.IsTrue(hand.CanSplit);
        }

        [TestMethod]
        public void NewHandWithTwoOfTheSameCardsResultInCanSplit()
        {
            var hand = new HandPlayer();
            hand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            hand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            Assert.IsTrue(hand.CanSplit);
        }
    }
}