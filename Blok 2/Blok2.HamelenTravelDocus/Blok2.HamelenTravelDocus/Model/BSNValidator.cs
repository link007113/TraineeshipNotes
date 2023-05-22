using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blok2.HamelenTravelDocus.Model
{
    public class BSNValidator
    {
        public static string NormalizeBSN(string bsn)
        {
            if (bsn.Length == 8)
            {
                bsn = "0" + bsn;
            }
            return bsn;
        }

        public static bool ValidateBSN(string bsn)
        {
            bsn = NormalizeBSN(bsn);

            if (bsn.Length != 9 || !IsNumeric(bsn))
            {
                return false;
            }

            int sum = 0;
            for (int i = 0; i < bsn.Length - 1; i++)
            {
                int digit = int.Parse(bsn[i].ToString());
                sum += (9 - i) * digit;
            }

            int lastDigit = int.Parse(bsn[bsn.Length - 1].ToString());
            sum += (-1) * lastDigit;

            return sum % 11 == 0;
        }

        private static bool IsNumeric(string value)
        {
            return value.All(char.IsDigit);
        }

        public static string GenerateValidBSN()
        {
            Random random = new Random();
            int[] digits = new int[9];
            for (int i = 0; i < 8; i++)
            {
                digits[i] = random.Next(0, 9);
            }

            int[] factors = { 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int sum = 0;
            for (int i = 0; i < 8; i++)
            {
                sum += digits[i] * factors[i];
            }

            int remainder = sum % 11;
            int lastDigit = remainder == 0 ? 0 : 11 - remainder;

            digits[8] = lastDigit;

            string bsn = string.Join("", digits);
            if (ValidateBSN(bsn))
            {
                return bsn;
            }
            else
            {
                return GenerateValidBSN();
            }
        }
    }
}