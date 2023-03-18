using System.Text.RegularExpressions;

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

        public static bool IsPalindrome(string input, bool doExtraCheck = false)
        {
            if (input == null)
            {
                input = string.Empty;
            }

            if (doExtraCheck)
            {
                Regex rgx = new Regex("[^a-zA-Z]");
                input = rgx.Replace(input, "");

            }

            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            string reversedString = new string(chars);
            return input.ToLower() == reversedString.ToLower();
        }



    }
}