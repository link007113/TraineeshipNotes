namespace Blok1.BlackJack.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestInitialize]
        public void Arrange()
        {
            _sut = new Player("Alice");
        }

        [TestMethod]
        public void NewPlayerHasBalanceOf20()
        {
            Assert.AreEqual(20M, _sut.Balance);
        }

        [TestMethod]
        public void NewPlayerHasBalanceOf9AfterBetOf11()
        {
            _sut.PlaceBet(9);
            Assert.AreEqual(11, _sut.Balance);
        }

        [TestMethod]
        public void NewPlayerHasBetOf30ResultsInArgumentOutOfRangeException()
        {
            void act()
            {
                _sut.PlaceBet(30);
            }
            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }

        [TestMethod]
        public void NewPlayerHasBetOfZero()
        {
            Assert.AreEqual(0, _sut.PrimaryHand.Bet);
        }

        [TestMethod]
        public void NewPlayerHasHandOfZero()
        {
            Assert.AreEqual(0, _sut.PrimaryHand.TotalValue);
        }

        [TestMethod]
        public void NewPlayerHasNameOfAlice()
        {
            Assert.AreEqual("Alice", _sut.Name);
        }

        [TestMethod]
        public void PlayerHandAddWinningsBlackJackGivesBalancePlusTwoPointFiveTimesTheBet()
        {
            // Arrange
            _sut.PlaceBet(10);

            // Act
            _sut.AddWinningsBlackJack(_sut.PrimaryHand);

            // Assert
            Assert.AreEqual(35, _sut.Balance);
        }

        [TestMethod]
        public void PlayerHandAddWinningsGivesBalancePlusDoubleBet()
        {
            // Arrange
            _sut.PlaceBet(10);

            // Act
            _sut.AddWinnings(_sut.PrimaryHand);

            // Assert
            Assert.AreEqual(30, _sut.Balance);
        }

        [TestMethod]
        public void PlayerHandClearGivesClearHand()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));

            // Act
            _sut.ClearHands();

            // Assert
            Assert.AreEqual(0, _sut.PrimaryHand.Cards.Count);
        }

        [TestMethod]
        public void PlayerHandReturnBetGivesBalancePlusBet()
        {
            // Arrange
            _sut.PlaceBet(10);
            // Act
            _sut.ReturnBet();
            // Assert
            Assert.AreEqual(20, _sut.Balance);
        }

        [TestMethod]
        public void PlayerSplitPairResultsInMoreHands()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            // Act
            _sut.SplitPair();
            // Assert
            Assert.AreEqual(2, _sut.Hands.Count);
        }

        [TestMethod]
        public void PlayerSplitPairResultsInTwoHandsOfTen()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.PrimaryHand.AddCard(new Card(Suit.Diamonds, Rank.Ten));
            // Act
            _sut.SplitPair();
            // Assert
            Assert.AreEqual(10, _sut.Hands[0].TotalValue);
            Assert.AreEqual(10, _sut.Hands[1].TotalValue);
        }

        private Player _sut;
    }
}