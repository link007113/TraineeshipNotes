using Blok1.BlackJack.Enums;
using Blok1.BlackJack.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void NewPlayerHasBalanceOf20()
        {
            var player = new Player("Test");
            Assert.AreEqual(20M, player.Balance);
        }

        [TestMethod]
        public void NewPlayerHasNameOfTest()
        {
            var player = new Player("Test");
            Assert.AreEqual("Test", player.Name);
        }

        [TestMethod]
        public void NewPlayerHasHandOfZero()
        {
            var player = new Player("Test");
            Assert.AreEqual(0, player.Hand.TotalValue);
        }

        [TestMethod]
        public void NewPlayerHasBetOfZero()
        {
            var player = new Player("Test");
            Assert.AreEqual(0, player.Hand.Bet);
        }

        [TestMethod]
        public void NewPlayerHasBalanceOf10AfterBetOf10()
        {
            var player = new Player("Test");
            player.PlaceBet(10);
            Assert.AreEqual(10, player.Balance);
        }

        [TestMethod]
        public void NewPlayerHasBetOf30ResultsInArgumentOutOfRangeException()
        {
            var player = new Player("Test");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => player.PlaceBet(30));
        }

        [TestMethod]
        public void PlayerHandClearGivesClearHand()
        {
            // Arrange
            var player = new Player("Test");
            player.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));

            // Act
            player.ClearHand();

            // Assert
            Assert.AreEqual(0, player.Hand.Cards.Count);
        }

        [TestMethod]
        public void PlayerHandAddWinningsGivesBalancePlusDoubleBet()
        {
            // Arrange
            var player = new Player("Test");
            player.Hand.PlaceBet(10);

            // Act
            player.AddWinnings();

            // Assert
            Assert.AreEqual(40, player.Balance);
        }

        [TestMethod]
        public void PlayerHandAddWinningsBlackJackGivesBalancePlusTwoPointFiveTimesTheBet()
        {
            // Arrange
            var player = new Player("Test");
            player.Hand.PlaceBet(10);

            // Act
            player.AddWinningsBlackJack();

            // Assert
            Assert.AreEqual(45, player.Balance);
        }

        [TestMethod]
        public void PlayerHandReturnBetGivesBalancePlusBet()
        {
            // Arrange
            var player = new Player("Test");
            player.Hand.PlaceBet(10);
            // Act
            player.ReturnBet();
            // Assert
            Assert.AreEqual(30, player.Balance);
        }

        [TestMethod]
        public void PlayerSplitPairResultsInMoreHands()
        {
            // Arrange
            var player = new Player("Test");
            player.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            player.Hand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            // Act
            player.SplitPair();
            // Assert
            Assert.AreEqual(2, player.Hands.Count);
        }
    }
}