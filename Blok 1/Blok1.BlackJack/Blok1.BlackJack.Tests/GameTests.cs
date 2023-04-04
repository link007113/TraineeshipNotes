namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestInitialize]
        public void Arrange()
        {
            _sut = new Game("Alice");
        }

        [TestMethod]
        public void GameDealsCardsResultInDealerHaveOneVisibleAndOneInvisibleCard()
        {
            _sut.DealCards();
            Assert.AreEqual(1, _sut.Dealer.PrimaryHand.Cards.Count(c => c.FaceUp));
            Assert.AreEqual(1, _sut.Dealer.PrimaryHand.Cards.Count(c => !c.FaceUp));
        }

        [TestMethod]
        public void GameDealsCardsResultInPlayerAndDealerHaveTwoCards()
        {
            _sut.DealCards();
            Assert.AreEqual(2, _sut.Player.PrimaryHand.Cards.Count);
            Assert.AreEqual(2, _sut.Dealer.PrimaryHand.Cards.Count);
        }

        [TestMethod]
        public void GameDecideWinnerOutcomeIsDealerWin()
        {
            // Arrange
            _sut.Player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Two));
            _sut.Player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Three));
            _sut.Dealer.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.Dealer.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));

            // Act
            _sut.DecideWinner();
            string outcome = _sut.Player.PrimaryHand.GameResult;

            Assert.AreEqual("You lose!", outcome);
        }

        [TestMethod]
        public void GameDecideWinnerOutcomeIsPlayerWin()
        {
            // Arrange
            _sut.Player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.Player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.Dealer.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Two));
            _sut.Dealer.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Three));

            // Act
            _sut.DecideWinner();
            string outcome = _sut.Player.PrimaryHand.GameResult;

            // Assert
            Assert.AreEqual("You win!", outcome);
        }

        [TestMethod]
        public void GameDecideWinnerOutcomeIsPush()
        {
            // Arrange
            _sut.Player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.Player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.Dealer.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.Dealer.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));

            // Act
            _sut.DecideWinner();
            string outcome = _sut.Player.PrimaryHand.GameResult;

            // Assert
            Assert.AreEqual("Push!", outcome);
        }

        [TestMethod]
        public void GamePlayerDoubleDownResultsInDoubleBet()
        {
            // Arrange
            decimal bet = 5;
            _sut.PlayerPlaceBet(bet);
            _sut.DealCards();

            // Act
            _sut.PlayerDoubleDown(_sut.Player.PrimaryHand);

            // Assert

            Assert.AreEqual(bet * 2, _sut.Player.PrimaryHand.Bet);
        }

        [TestMethod]
        public void GamePlayerHitResultInPlayerHaveThreeCardsAndDealerHaveTwoCards()
        {
            // Arrange
            _sut.DealCards();
            // Act
            _sut.PlayerHit(_sut.Player.PrimaryHand);
            // Assert
            Assert.AreEqual(3, _sut.Player.PrimaryHand.Cards.Count);
            Assert.AreEqual(2, _sut.Dealer.PrimaryHand.Cards.Count);
        }

        [TestMethod]
        public void GamePlayerPlacesBetOf10SetsBalanceOfPlayerTo10()
        {
            // Act
            _sut.PlayerPlaceBet(10);
            // Assert
            Assert.AreEqual(10M, _sut.Player.Balance);
        }

        [TestMethod]
        public void GamePlayerPlacesBetOf30ResultsInArgumentOutOfRangeException()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _sut.PlayerPlaceBet(30));
        }

        [TestMethod]
        public void GamePlayerSplitPairResultsInTwoHandsOfTen()
        {
            // Arrange

            _sut.Player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.Player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            // Act
            _sut.PlayerSplit(_sut.Player.PrimaryHand);
            // Assert
            Assert.AreEqual(2, _sut.Player.Hands.Count);
            Assert.AreEqual(2, _sut.Player.Hands[0].Cards.Count);
            Assert.AreEqual(2, _sut.Player.Hands[1].Cards.Count);
        }

        [TestMethod]
        public void GamePlayerStandResultsInDealerAllCardsVisible()
        {
            // Arrange
            _sut.DealCards();
            _sut.PlayerHit(_sut.Player.PrimaryHand);

            // Act
            _sut.PlayerStand();

            //Assert
            Assert.IsTrue(_sut.Dealer.PrimaryHand.Cards.All(c => c.FaceUp));
        }

        [TestMethod]
        public void GamePlayerStandResultsInDealerHandTotalValueIsHigherThan17()
        {
            // Arrange
            _sut.DealCards();
            _sut.PlayerHit(_sut.Player.PrimaryHand);

            // Act
            _sut.PlayerStand();

            //Assert
            Assert.IsTrue(_sut.Dealer.PrimaryHand.TotalValue > 17);
        }

        [TestMethod]
        public void GameResetResultsInResetGame()
        {
            // Arrange
            _sut.DealCards();
            _sut.PlayerHit(_sut.Player.PrimaryHand);
            _sut.PlayerStand();

            // Act
            _sut.RestartGame();

            // Assert
            Assert.AreEqual(0, _sut.Player.PrimaryHand.Cards.Count);
            Assert.AreEqual(0, _sut.Dealer.PrimaryHand.Cards.Count);
            Assert.AreEqual(312, _sut.Shoe.Cards.Count);
        }

        [TestMethod]
        public void NewGameWithNameTestHasDealerWithNameDealer()
        {
            Assert.AreEqual("Dealer", _sut.Dealer.Name);
        }

        [TestMethod]
        public void NewGameWithNameTestHasPlayerWithBalanceOf20()
        {
            Assert.AreEqual(20M, _sut.Player.Balance);
        }

        [TestMethod]
        public void NewGameWithNameTestHasPlayerWithNameTest()
        {
            Assert.AreEqual("Alice", _sut.Player.Name);
        }

        [TestMethod]
        public void ToString_ShouldContainPlayerNameAndBalanceAndPrimaryHand_WhenPlayerHasOneHand()
        {
            // Arrange
            _sut.Player.PrimaryHand.AddCard(new Card(Suit.Hearts, Rank.Ace));
            _sut.Player.PrimaryHand.AddCard(new Card(Suit.Spades, Rank.Jack));

            // Act
            var actual = _sut.ToString();

            // Assert
            Assert.IsTrue(actual.Contains("Balance of Alice:\t20"));
            Assert.IsTrue(actual.Contains("Alice's hand:"));
            Assert.IsTrue(actual.Contains("Ace of Hearts"));
            Assert.IsTrue(actual.Contains("Jack of Spades"));
        }

        private Game _sut;
    }
}