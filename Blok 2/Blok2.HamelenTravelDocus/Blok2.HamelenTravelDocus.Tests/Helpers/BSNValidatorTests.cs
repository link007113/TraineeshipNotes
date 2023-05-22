using Blok2.HamelenTravelDocus.Helpers;

namespace Blok2.HamelenTravelDocus.Tests.Helpers
{
    [TestClass]
    public class BSNValidatorTests
    {
        [TestMethod]
        public void NormalizeBSN_InputWith8Characters_ReturnsNormalizedBSN()
        {
            // Arrange
            string bsn = "12345678";

            // Act
            string normalizedBSN = BSNValidator.NormalizeBSN(bsn);

            // Assert
            Assert.AreEqual("012345678", normalizedBSN);
        }

        [TestMethod]
        public void NormalizeBSN_InputWith9Characters_ReturnsUnchangedBSN()
        {
            // Arrange
            string bsn = "012345678";

            // Act
            string normalizedBSN = BSNValidator.NormalizeBSN(bsn);

            // Assert
            Assert.AreEqual(bsn, normalizedBSN);
        }

        [TestMethod]
        public void GenerateValidBSN_ReturnsValidBSN()
        {
            // Arrange

            // Act
            string bsn = BSNValidator.GenerateValidBSN();

            // Assert
            Assert.IsTrue(BSNValidator.ValidateBSN(bsn));
        }

        [TestMethod]
        public void ValidateBSN_ValidBSN_ReturnsTrue()
        {
            // Arrange
            string bsn = "123456782";

            // Act
            bool isValid = BSNValidator.ValidateBSN(bsn);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ValidateBSN_InvalidLength_ReturnsFalse()
        {
            // Arrange
            string bsn = "12345678";

            // Act
            bool isValid = BSNValidator.ValidateBSN(bsn);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateBSN_NonNumericBSN_ReturnsFalse()
        {
            // Arrange
            string bsn = "12345678a";

            // Act
            bool isValid = BSNValidator.ValidateBSN(bsn);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateBSN_InvalidChecksum_ReturnsFalse()
        {
            // Arrange
            string bsn = "123456781";

            // Act
            bool isValid = BSNValidator.ValidateBSN(bsn);

            // Assert
            Assert.IsFalse(isValid);
        }
    }
}