using Dag04.StringDemo;

namespace Dag04.StringDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAToE()
        {
            string input = "water";
            string output = StringOperations.AToE(input);
            Assert.AreEqual("weter", output);
        }

        [TestMethod]
        public void TestAToEAndEToI()
        {
            string input = "water";
            string output = StringOperations.AToEAndEToI(input);
            Assert.AreEqual("wetir", output);
        }

        [TestMethod]
        public void TestIsPalindrome()
        {
            string input1 = "water";
            bool output1 = StringOperations.IsPalindrome(input1);
            string input2 = "lepel";
            bool output2 = StringOperations.IsPalindrome(input2);
            string input3 = null;
            bool output3 = StringOperations.IsPalindrome(input3);


            Assert.AreEqual(false, output1);
            Assert.AreEqual(true, output2);
            Assert.AreEqual(true, output3);
        }
    }
}