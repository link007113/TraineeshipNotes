using Dag04.StringDemo;

namespace Dag04.StringDemo.Tests
{
    [TestClass]
    public class UnitTest1
    {
        //Blue Slope
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
        // Red Slope
        [TestMethod]
        public void TestIsPalindrome()
        {
            string input1 = "water";
            bool output1 = StringOperations.IsPalindrome(input1);
            string input2 = "lepel";
            bool output2 = StringOperations.IsPalindrome(input2);
            string input3 = "Lepel";
            bool output3 = StringOperations.IsPalindrome(input3);


            Assert.AreEqual(false, output1);
            Assert.AreEqual(true, output2);
            Assert.AreEqual(true, output3);
        }
        // Black Slope
        [TestMethod]
        public void TestIsPalindromeExtra()
        {
            string input = "A man, a plan, a canal: Panama";
            bool doExtraCheck = true;
            bool output = StringOperations.IsPalindrome(input, doExtraCheck);
            Assert.AreEqual(true, output);    
        }
    }
}