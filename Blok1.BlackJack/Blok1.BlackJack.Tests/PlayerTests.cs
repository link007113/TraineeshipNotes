using Blok1.BlackJack.Enums;
using Blok1.BlackJack.Classes;

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
            Assert.AreEqual(0, player.PrimaryHand.TotalValue);
        }

        [TestMethod]
        public void NewPlayerHasBetOfZero()
        {
            var player = new Player("Test");
            Assert.AreEqual(0, player.PrimaryHand.Bet);
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
            player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));

            // Act
            player.ClearHands();

            // Assert
            Assert.AreEqual(0, player.PrimaryHand.Cards.Count);
        }

        [TestMethod]
        public void PlayerHandAddWinningsGivesBalancePlusDoubleBet()
        {
            // Arrange
            var player = new Player("Test");
            player.PrimaryHand.PlaceBet(10);

            // Act
            player.AddWinnings(player.PrimaryHand);

            // Assert
            Assert.AreEqual(40, player.Balance);
        }

        [TestMethod]
        public void PlayerHandAddWinningsBlackJackGivesBalancePlusTwoPointFiveTimesTheBet()
        {
            // Arrange
            var player = new Player("Test");
            player.PrimaryHand.PlaceBet(10);

            // Act
            player.AddWinningsBlackJack(player.PrimaryHand);

            // Assert
            Assert.AreEqual(45, player.Balance);
        }

        [TestMethod]
        public void PlayerHandReturnBetGivesBalancePlusBet()
        {
            // Arrange
            var player = new Player("Test");
            player.PrimaryHand.PlaceBet(10);
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
            player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            // Act
            player.SplitPair();
            // Assert
            Assert.AreEqual(2, player.Hands.Count);
        }

        [TestMethod]
        public void PlayerSplitPairResultsInTwoHandsOfTen()
        {
            // Arrange
            var player = new Player("Test");
            player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            player.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            // Act
            player.SplitPair();
            // Assert
            Assert.AreEqual(10, player.Hands[0].TotalValue);
            Assert.AreEqual(10, player.Hands[1].TotalValue);
        }
    }
}