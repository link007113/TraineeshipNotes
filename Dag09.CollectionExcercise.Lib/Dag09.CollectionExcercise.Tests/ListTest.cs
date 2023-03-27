using Dag09.CollectionExcercise.Lib;

namespace Dag09.CollectionExcercise.Tests
{
    [TestClass]
    public class ListTest
    {
        private SortedListImpl<int> _sut;

        [TestInitialize]
        public void TestIntialize()
        {
            _sut = new SortedListImpl<int>();
        }

        [TestMethod]
        public void Add_EmptyList_GivesLength()
        {
            _sut.Add(2);

            Assert.AreEqual(1, _sut.Length);
        }

        [TestMethod]
        public void Add_EmptyList_Gives2OnPosistion0()
        {
            _sut.Add(2);

            Assert.AreEqual(2, _sut[0]);
        }

        [TestMethod]
        public void IndexNegative1_ListWithElement_GivesIndexOutOfRangeException()
        {
            _sut.Add(2);
            void act()
            {
                int item = _sut[-1];
            }

            Assert.ThrowsException<IndexOutOfRangeException>(act);
        }

        [TestMethod]
        public void Add_FiveElemenst_GiveSortedList()
        {
            // Arrange
            _sut.Add(3);
            _sut.Add(2);
            _sut.Add(7);
            _sut.Add(5);

            // Act
            _sut.Add(11);

            //Assert
            Assert.AreEqual(2, _sut[0]);
            Assert.AreEqual(3, _sut[1]);
            Assert.AreEqual(5, _sut[2]);
            Assert.AreEqual(7, _sut[3]);
            Assert.AreEqual(11, _sut[4]);
        }

        [TestMethod]
        public void Add_SixWithDuplicatesElemenst_GiveSortedList()
        {
            // Arrange
            _sut.Add(3);
            _sut.Add(2);
            _sut.Add(5);
            _sut.Add(7);
            _sut.Add(5);

            // Act
            _sut.Add(11);

            //Assert
            Assert.AreEqual(2, _sut[0]);
            Assert.AreEqual(3, _sut[1]);
            Assert.AreEqual(5, _sut[2]);
            Assert.AreEqual(5, _sut[3]);
            Assert.AreEqual(7, _sut[4]);
            Assert.AreEqual(11, _sut[5]);
        }

        [TestMethod]
        public void Add_FiveElemenst_ForEachsetMaxInt()
        {
            // Arrange
            _sut.Add(2);
            _sut.Add(3);
            _sut.Add(22);
            _sut.Add(5);
            _sut.Add(7);
            _sut.Add(11);
            int maxInt = 0;

            foreach (int i in _sut)
            {
                maxInt = i;
            }

            //Assert
            Assert.AreEqual(22, maxInt);
        }
    }
}