using Blok1.BlackJack.Enums;
using Blok1.BlackJack.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;

namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void NewGameWithNameTestHasPlayerWithNameTest()
        {
            var game = new Game("Test");
            Assert.AreEqual("Test", game.Player.Name);
        }

        [TestMethod]
        public void NewGameWithNameTestHasDealerWithNameDealer()
        {
            var game = new Game("Test");
            Assert.AreEqual("Dealer", game.Dealer.Name);
        }

        [TestMethod]
        public void NewGameWithNameTestHasPlayerWithBalanceOf20()
        {
            var game = new Game("Test");
            Assert.AreEqual(20M, game.Player.Balance);
        }

        [TestMethod]
        public void GamePlayerPlacesBetOf10SetsBalanceOfPlayerTo10()
        {
            // Arrange
            var game = new Game("Test");
            // Act
            game.PlayerPlaceBet(10);
            // Assert
            Assert.AreEqual(10M, game.Player.Balance);
        }

        [TestMethod]
        public void GamePlayerPlacesBetOf30ResultsInArgumentOutOfRangeException()
        {
            var game = new Game("Test");

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => game.PlayerPlaceBet(30));
        }

        [TestMethod]
        public void GameDealsCardsResultInPlayerAndDealerHaveTwoCards()
        {
            var game = new Game("Test");
            game.DealCards();
            Assert.AreEqual(2, game.Player.Hand.Cards.Count);
            Assert.AreEqual(2, game.Dealer.Hand.Cards.Count);
        }

        [TestMethod]
        public void GameDealsCardsResultInDealerHaveOneVisibleAndOneInvisibleCard()
        {
            var game = new Game("Test");
            game.DealCards();
            Assert.AreEqual(1, game.Dealer.Hand.Cards.Count(c => c.Visible));
            Assert.AreEqual(1, game.Dealer.Hand.Cards.Count(c => !c.Visible));
        }

        [TestMethod]
        public void GamePlayerHitResultInPlayerHaveThreeCardsAndDealerHaveTwoCards()
        {
            // Arrange
            var game = new Game("Test");
            game.DealCards();
            // Act
            game.PlayerHit();
            // Assert
            Assert.AreEqual(3, game.Player.Hand.Cards.Count);
            Assert.AreEqual(2, game.Dealer.Hand.Cards.Count);
        }
    }
}