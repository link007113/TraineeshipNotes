using Blok1.BlackJack.Enums;
using Blok1.BlackJack.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using System.Diagnostics;

namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class GameTests
    {
        private Game _sut;

        [TestInitialize]
        public void TestIntialize()
        {
            _sut = new Game("Test");
        }

        [TestMethod]
        public void NewGameWithNameTestHasPlayerWithNameTest()
        {
            Assert.AreEqual("Test", _sut.Player.Name);
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
        public void GameDealsCardsResultInPlayerAndDealerHaveTwoCards()
        {
            _sut.DealCards();
            Assert.AreEqual(2, _sut.Player.Hand.Cards.Count);
            Assert.AreEqual(2, _sut.Dealer.Hand.Cards.Count);
        }

        [TestMethod]
        public void GameDealsCardsResultInDealerHaveOneVisibleAndOneInvisibleCard()
        {
            _sut.DealCards();
            Assert.AreEqual(1, _sut.Dealer.Hand.Cards.Count(c => c.Visible));
            Assert.AreEqual(1, _sut.Dealer.Hand.Cards.Count(c => !c.Visible));
        }

        [TestMethod]
        public void GamePlayerHitResultInPlayerHaveThreeCardsAndDealerHaveTwoCards()
        {
            // Arrange
            _sut.DealCards();
            // Act
            _sut.PlayerHit();
            // Assert
            Assert.AreEqual(3, _sut.Player.Hand.Cards.Count);
            Assert.AreEqual(2, _sut.Dealer.Hand.Cards.Count);
        }

        [TestMethod]
        public void GameDecideWinnerOutcomeIsPush()
        {
            // Arrange
            _sut.Player.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.Player.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.Dealer.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.Dealer.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));

            // Act
            _sut.DecideWinner();
            string outcome = _sut.Player.Hand.GameResult;

            // Assert
            Assert.AreEqual("Push!", outcome);
        }

        [TestMethod]
        public void GameDecideWinnerOutcomeIsDealerWin()
        {
            // Arrange
            _sut.Player.Hand.AddCard(new Card(Suit.Clubs, Rank.Two));
            _sut.Player.Hand.AddCard(new Card(Suit.Clubs, Rank.Three));
            _sut.Dealer.Hand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.Dealer.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));

            // Act
            _sut.DecideWinner();
            string outcome = _sut.Player.Hand.GameResult;

            Assert.AreEqual("You lose!", outcome);
        }

        [TestMethod]
        public void GameDecideWinnerOutcomeIsPlayerWin()
        {
            // Arrange
            _sut.Player.Hand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.Player.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.Dealer.Hand.AddCard(new Card(Suit.Clubs, Rank.Two));
            _sut.Dealer.Hand.AddCard(new Card(Suit.Clubs, Rank.Three));

            // Act
            _sut.DecideWinner();
            string outcome = _sut.Player.Hand.GameResult;

            // Assert
            Assert.AreEqual("You win!", outcome);
        }

        [TestMethod]
        public void GameResetResultsInResetGame()
        {
            // Arrange
            _sut.DealCards();
            _sut.PlayerHit();
            _sut.PlayerStand();

            // Act
            _sut.RestartGame();

            // Assert
            Assert.AreEqual(0, _sut.Player.Hand.Cards.Count);
            Assert.AreEqual(0, _sut.Dealer.Hand.Cards.Count);
            Assert.AreEqual(312, _sut.Shoe.Cards.Count);
        }

        [TestMethod]
        public void GamePlayerStandResultsInDealerAllCardsVisible()
        {
            // Arrange
            _sut.DealCards();
            _sut.PlayerHit();

            // Act
            _sut.PlayerStand();

            //Assert
            Assert.IsTrue(_sut.Dealer.Hand.Cards.All(c => c.Visible));
        }

        [TestMethod]
        public void GamePlayerStandResultsInDealerHandTotalValueIsHigherThan17()
        {
            // Arrange
            _sut.DealCards();
            _sut.PlayerHit();

            // Act
            _sut.PlayerStand();

            //Assert
            Assert.IsTrue(_sut.Dealer.Hand.TotalValue > 17);
        }

        [TestMethod]
        public void GamePlayerDoubleDownResultsInDoubleBet()
        {
            // Arrange
            decimal bet = 5;
            _sut.PlayerPlaceBet(bet);
            _sut.DealCards();

            // Act
            _sut.PlayerDoubleDown();

            // Assert

            Assert.AreEqual(bet * 2, _sut.Player.Hand.Bet);
        }
    }
}