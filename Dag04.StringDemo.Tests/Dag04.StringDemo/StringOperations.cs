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
            if (input == null)
            {
                input = string.Empty;
            }

            char[] chars = input.ToCharArray();
            Array.Reverse(chars);
            string reversedString = new string(chars);
            return input == reversedString;
        }

        public static bool IsPalindromeExtraCheck(string input)
        {
            // Heel eerlijk, dit moest ik ff opzoeken...
            int left = 0;
            int right = input.Length - 1;
            while (left < right)
            {
                while (left < right && !char.IsLetterOrDigit(input[left]))
                {
                    left++;
                }

                while (left < right && !char.IsLetterOrDigit(input[right]))
                {
                    right--;
                }

                if (char.ToLower(input[left]) != char.ToLower(input[right]))
                {
                    return false;
                }

                left++;
                right--;
            }
            return true;
        }

    }
}