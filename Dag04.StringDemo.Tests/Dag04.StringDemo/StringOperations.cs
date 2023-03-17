namespace Dag04.StringDemo
{
    public class StringOperations
    {

        public static string AToE(string input)
        {
            return input.Replace('a', 'e');
        }

        public static string AToEAndEToI(string input)
        {
            return input.Replace('e', 'i').Replace('a', 'e'); 
        }

        public static bool IsPalindrome(string input)
        { 
            string reversedString = input.Reverse().ToString();
            return input == reversedString;        
        }

    }
}