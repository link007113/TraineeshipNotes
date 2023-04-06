namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class HandTests
    {
        [TestInitialize]
        public void Arrange()
        {
            _sut = new PlayerHand();
        }

        [TestMethod]
        public void IsCharlie_WhenHandHasFiveCardsAndIsNotBust_ShouldReturnTrue()
        {
            // Arrange
            _sut.AddCard(new Card(Suit.Hearts, Rank.Two));
            _sut.AddCard(new Card(Suit.Clubs, Rank.Three));
            _sut.AddCard(new Card(Suit.Spades, Rank.Four));
            _sut.AddCard(new Card(Suit.Diamonds, Rank.Five));
            _sut.AddCard(new Card(Suit.Hearts, Rank.Six));

            // Act
            var result = _sut.IsCharlie;

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsCharlie_WhenHandHasLessThanFiveCards_ShouldReturnFalse()
        {
            // Arrange
            _sut.AddCard(new Card(Suit.Hearts, Rank.Two));
            _sut.AddCard(new Card(Suit.Clubs, Rank.Three));
            _sut.AddCard(new Card(Suit.Spades, Rank.Four));
            _sut.AddCard(new Card(Suit.Diamonds, Rank.Five));

            // Act
            var result = _sut.IsCharlie;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsCharlie_WhenHandIsBust_ShouldReturnFalse()
        {
            // Arrange
            _sut.AddCard(new Card(Suit.Hearts, Rank.King));
            _sut.AddCard(new Card(Suit.Clubs, Rank.King));
            _sut.AddCard(new Card(Suit.Spades, Rank.King));
            _sut.AddCard(new Card(Suit.Diamonds, Rank.King));
            _sut.AddCard(new Card(Suit.Hearts, Rank.King));

            // Act
            var result = _sut.IsCharlie;

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void PlayerHand_GetsCards_ResultInBlackJack()
        {
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ten));
            Assert.IsTrue(_sut.IsBlackJack);
        }

        [TestMethod]
        public void PlayerHand_GetsCards_ResultInIsBust()
        {
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.AddCard(new Card(Suit.Clubs, Rank.King));
            _sut.AddCard(new Card(Suit.Clubs, Rank.Queen));
            Assert.IsTrue(_sut.IsBust);
        }

        [TestMethod]
        public void PlayerHand_GetsCards_ResultInNotBlackJack()
        {
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.AddCard(new Card(Suit.Clubs, Rank.Nine));
            Assert.IsFalse(_sut.IsBlackJack);
        }

        [TestMethod]
        public void PlayerHand_HasABetOfZero()
        {
            Assert.AreEqual(0, _sut.Bet);
        }

        [TestMethod]
        public void PlayerHand_HasBetOf10AfterPlaceBetOf10()
        {
            _sut.PlaceBet(10);
            Assert.AreEqual(10, _sut.Bet);
        }

        [TestMethod]
        public void PlayerHand_HasZeroTotalValue()
        {
            Assert.AreEqual(0, _sut.TotalValue);
        }

        [TestMethod]
        public void PlayerHand_WithAceAndKingAndTine_Gives21Instead31()
        {
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.AddCard(new Card(Suit.Clubs, Rank.King));
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ace));
            Assert.AreEqual(21, _sut.TotalValue);
        }

        [TestMethod]
        public void PlayerHand_WithOneCard_CannotDoubleDown()
        {
            _sut.AddCard(new Card(Suit.Hearts, Rank.Ace));
            Assert.IsFalse(_sut.CanDoubleDown);
        }

        [TestMethod]
        public void PlayerHand_WithOneCard_CannotSplit()
        {
            _sut.AddCard(new Card(Suit.Hearts, Rank.Ace));
            Assert.IsFalse(_sut.CanSplit);
        }

        [TestMethod]
        public void PlayerHand_WithOneCardHasTotalValueOfThatCard()
        {
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ten));
            Assert.AreEqual(10, _sut.TotalValue);
        }

        [TestMethod]
        public void PlayerHand_WithThreeCards_CannotDoubleDown()
        {
            _sut.AddCard(new Card(Suit.Hearts, Rank.Ace));
            _sut.AddCard(new Card(Suit.Hearts, Rank.Ten));
            _sut.AddCard(new Card(Suit.Clubs, Rank.Two));
            Assert.IsFalse(_sut.CanDoubleDown);
        }

        [TestMethod]
        public void PlayerHand_WithTwoCards_CanDoubleDown()
        {
            _sut.AddCard(new Card(Suit.Hearts, Rank.Ace));
            _sut.AddCard(new Card(Suit.Hearts, Rank.Ten));
            Assert.IsTrue(_sut.CanDoubleDown);
        }

        [TestMethod]
        public void PlayerHand_WithTwoCardsHasTotalValueOfThoseCards()
        {
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.AddCard(new Card(Suit.Clubs, Rank.Two));
            Assert.AreEqual(12, _sut.TotalValue);
        }

        [TestMethod]
        public void PlayerHand_WithTwoDifferentCardsWithSameValueResultInCanSplit()
        {
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.AddCard(new Card(Suit.Clubs, Rank.King));
            Assert.IsTrue(_sut.CanSplit);
        }

        [TestMethod]
        public void TotalValue_Hand_NotHigherThan21_WithFourAces()
        {
            _sut.AddCard(new Card(Suit.Hearts, Rank.Ace));
            _sut.AddCard(new Card(Suit.Diamonds, Rank.Ace));
            _sut.AddCard(new Card(Suit.Spades, Rank.Ace));
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ace));

            Assert.IsTrue(_sut.TotalValue <= 21);
        }

        [TestMethod]
        public void PlayerHand_WithTwoOfTheSameCardsResultInCanSplit()
        {
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.AddCard(new Card(Suit.Clubs, Rank.Ace));
            Assert.IsTrue(_sut.CanSplit);
        }

        [TestMethod]
        public void ShowAllCards_InDealerHand_Results_AllCardsFaceUp()
        {
            // Arrange
            DealerHand DealerHand = new DealerHand();
            DealerHand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            DealerHand.AddCard(new Card(Suit.Clubs, Rank.Ten, false));

            // Act
            DealerHand.ShowAllCards();

            // Assert
            Assert.IsTrue(DealerHand.Cards.All(c => c.FaceUp));
        }

        private PlayerHand _sut = new PlayerHand();
    }
}