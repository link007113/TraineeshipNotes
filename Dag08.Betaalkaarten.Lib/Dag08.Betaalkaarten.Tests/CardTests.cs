using Dag08.Betaalkaarten.Lib;

namespace Dag08.Betaalkaarten.Tests
{
    [TestClass]
    public class CardTests
    {
        private NormalCard _normalCard = null!;
        private VipCards _VipCardWithNormalDiscount = null!;
        private VipCards _VipCardWithExtraDiscount = null!;

        [TestInitialize]
        public void TestIntialize()
        {
            _normalCard = new NormalCard("Anthony", 100M);
            _VipCardWithNormalDiscount = new VipCards("Anthony", 100M);
            _VipCardWithExtraDiscount = new VipCards("Anthony", 100M, 15M);
        }

        [TestMethod]
        public void Pay_Cards_AboveZero_Results_true()
        {
            // Act
            bool paymentSucceedsNormalCard = _normalCard.Pay(10);
            bool paymentSucceedsVipCardWithNormalDiscount = _VipCardWithNormalDiscount.Pay(10);
            bool paymentSucceedsVipCardWithExtraDiscount = _VipCardWithExtraDiscount.Pay(10);
            //Assert
            Assert.IsTrue(paymentSucceedsNormalCard, "Normal Card");
            Assert.IsTrue(paymentSucceedsVipCardWithNormalDiscount, "Vip Card with normal discount");
            Assert.IsTrue(paymentSucceedsVipCardWithExtraDiscount, "Vip Card with extra discount");
        }

        [TestMethod]
        public void Pay_Cards_UnderZero_Results_false()
        {
            // Act
            bool paymentSucceedsNormalCard = _normalCard.Pay(-10);
            bool paymentSucceedsVipCardWithNormalDiscount = _VipCardWithNormalDiscount.Pay(-10);
            bool paymentSucceedsVipCardWithExtraDiscount = _VipCardWithExtraDiscount.Pay(-10);
            //Assert
            Assert.IsFalse(paymentSucceedsNormalCard, "Normal Card");
            Assert.IsFalse(paymentSucceedsVipCardWithNormalDiscount, "Vip Card with normal discount");
            Assert.IsFalse(paymentSucceedsVipCardWithExtraDiscount, "Vip Card with extra discount");
        }

        [TestMethod]
        public void Pay_Cards_AboveZero_Results_In_Altered_Saldis()
        {
            // Act
            _normalCard.Pay(10);
            _VipCardWithNormalDiscount.Pay(10);
            _VipCardWithExtraDiscount.Pay(10);
            //Assert
            Assert.AreEqual(90M, _normalCard.Saldo, "Normal Card");
            Assert.AreEqual(91M, _VipCardWithNormalDiscount.Saldo, "Vip Card with normal discount");
            Assert.AreEqual(91.5M, _VipCardWithExtraDiscount.Saldo, "Vip Card with extra discount");
        }
    }
}