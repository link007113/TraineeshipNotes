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
        public void GetCanDoubleDown_WithInsufficientBalance_ReturnsFalse()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.PrimaryHand.AddCard(new Card(Suit.Diamonds, Rank.King));
            _sut.PlaceBet(5M);
            _sut.Balance = 1M;

            // Act
            var actual = _sut.GetCanDoubleDown(_sut.PrimaryHand);

            // Assert
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void GetCanDoubleDown_WithInvalidHand_ReturnsFalse()
        {
            // Arrange

            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.PrimaryHand.AddCard(new Card(Suit.Diamonds, Rank.King));
            _sut.PrimaryHand.AddCard(new Card(Suit.Diamonds, Rank.King));

            // Act
            var actual = _sut.GetCanDoubleDown(_sut.PrimaryHand);

            // Assert
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void GetCanDoubleDown_WithValidHand_ReturnsTrue()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Hearts, Rank.Ace));
            _sut.PrimaryHand.AddCard(new Card(Suit.Hearts, Rank.Ten));

            // Act
            var actual = _sut.GetCanDoubleDown(_sut.PrimaryHand);

            // Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void GetCanSplit_WithInsufficientBalance_ReturnsFalse()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.PrimaryHand.AddCard(new Card(Suit.Diamonds, Rank.Ace));
            _sut.PlaceBet(5M);
            _sut.Balance = 1M;

            // Act
            var actual = _sut.GetCanSplit(_sut.PrimaryHand);

            // Assert
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void GetCanSplit_WithInvalidHand_ReturnsFalse()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.PrimaryHand.AddCard(new Card(Suit.Diamonds, Rank.Ten));

            // Act
            var actual = _sut.GetCanSplit(_sut.PrimaryHand);

            // Assert
            Assert.AreEqual(false, actual);
        }

        [TestMethod]
        public void GetCanSplit_WithValidHand_ReturnsTrue()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.PrimaryHand.AddCard(new Card(Suit.Diamonds, Rank.Ace));

            // Act
            var actual = _sut.GetCanSplit(_sut.PrimaryHand);

            // Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void NewPlayer_HasBalanceOf20()
        {
            Assert.AreEqual(20M, _sut.Balance);
        }

        [TestMethod]
        public void NewPlayer_HasBetOf30_ResultsInArgumentOutOfRangeException()
        {
            void act()
            {
                _sut.PlaceBet(30);
            }
            Assert.ThrowsException<ArgumentOutOfRangeException>(act);
        }

        [TestMethod]
        public void NewPlayer_HasBetOfZero()
        {
            Assert.AreEqual(0, _sut.PrimaryHand.Bet);
        }

        [TestMethod]
        public void NewPlayer_HasHandOfZero()
        {
            Assert.AreEqual(0, _sut.PrimaryHand.TotalValue);
        }

        [TestMethod]
        public void NewPlayer_HasNameOfAlice()
        {
            Assert.AreEqual("Alice", _sut.Name);
        }

        [TestMethod]
        public void NewPlayerHas_BalanceOf9_AfterBetOf11()
        {
            _sut.PlaceBet(9);
            Assert.AreEqual(11, _sut.Balance);
        }

        [TestMethod]
        public void PlayerHand_AddWinnings_GivesBalancePlusDoubleBet()
        {
            // Arrange
            _sut.PlaceBet(10);

            // Act
            _sut.AddWinnings(_sut.PrimaryHand);

            // Assert
            Assert.AreEqual(30, _sut.Balance);
        }

        [TestMethod]
        public void PlayerHand_AddWinningsBlackJack_GivesBalancePlusTwoPointFiveTimesTheBet()
        {
            // Arrange
            _sut.PlaceBet(10);

            // Act
            _sut.AddWinningsBlackJack(_sut.PrimaryHand);

            // Assert
            Assert.AreEqual(35, _sut.Balance);
        }

        [TestMethod]
        public void PlayerHand_ClearGives_ClearHand()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));

            // Act
            _sut.ClearHands();

            // Assert
            Assert.AreEqual(0, _sut.PrimaryHand.Cards.Count());
        }

        [TestMethod]
        public void PlayerHand_ReturnBet_GivesBalancePlusBet()
        {
            // Arrange
            _sut.PlaceBet(10);
            // Act
            _sut.AddWinningsPush(_sut.PrimaryHand);
            // Assert
            Assert.AreEqual(20, _sut.Balance);
        }

        [TestMethod]
        public void PlayerSplit_PairResults_InTwoHandsOfTen()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.PrimaryHand.AddCard(new Card(Suit.Diamonds, Rank.Ten));
            // Act
            _sut.SplitPair();
            // Assert
            Assert.AreEqual(10, _sut.Hands.First().TotalValue);
            Assert.AreEqual(10, _sut.Hands.Skip(1).First().TotalValue);
        }

        [TestMethod]
        public void SplitPair_ResultsInHandsIsSplit()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            // Act
            _sut.SplitPair();
            // Assert
            Assert.IsTrue(_sut.Hands.First().IsSplit);
            Assert.IsTrue(_sut.Hands.Skip(1).First().IsSplit);
        }

        [TestMethod]
        public void SplitPair_ResultsInMoreHands()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            // Act
            _sut.SplitPair();
            // Assert
            Assert.AreEqual(2, _sut.Hands.Count());
        }

        [TestMethod]
        public void SplitPair_ResultsInSplitHandsCannotBeBlackJack()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ace));
            // Act
            _sut.SplitPair();
            _sut.Hands.First().AddCard(new Card(Suit.Diamonds, Rank.King));
            _sut.Hands.Skip(1).First().AddCard(new Card(Suit.Diamonds, Rank.King));
            // Assert
            Assert.IsFalse(_sut.Hands.First().IsBlackJack);
            Assert.IsFalse(_sut.Hands.Skip(1).First().IsBlackJack);
        }

        [TestMethod]
        public void SplitPair_ResultsInTwoHandsWithSameBet()
        {
            // Arrange
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            _sut.PrimaryHand.AddCard(new Card(Suit.Clubs, Rank.Ten));
            // Act
            _sut.SplitPair();
            // Assert
            Assert.AreEqual(_sut.Hands.First().Bet, _sut.Hands.Skip(1).First().Bet);
        }

        private Player _sut = new("Alice");
    }
}