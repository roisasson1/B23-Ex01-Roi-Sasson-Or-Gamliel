using System;
using System.Linq;

namespace Ex01_05
{
    public class Program
    {
        public static void Main()
        {
            string userStr = ReadStrFromUser();
            Console.WriteLine(MessageToScreen(userStr));
        }

        public static string ReadStrFromUser()
        {
            Console.WriteLine("Hello, please enter a 6 digits number:");
            string userStr = Console.ReadLine();

            while (!IsValid(userStr))
            {
                System.Console.WriteLine("The number is invalid! try again:");
                userStr = System.Console.ReadLine();
            }

            return userStr;
        }
        
        public static bool IsValid(string i_str)
        {
            bool isNumber = i_str.All(char.IsDigit);
            bool valid = (isNumber && i_str.Length == 6);

            return valid;
        }

        public static string MessageToScreen(string i_str)
        {
            return string.Format(
$@"The number of digits greater than the units digit is: {FindNumOfDigitsGreaterThanUnitsDigit(i_str)}.
The smallest digit is: {FindSmallestDigit(i_str)}.
The number of digits which are divided by 3 is: {FindNumOfDigitsDividedByThree(i_str)}.
The average of the digits in the number is: {FindAvgOfDigits(i_str)}."
            );
        }

        public static int FindNumOfDigitsGreaterThanUnitsDigit(string i_str)
        {
            int unitsDigit = i_str[i_str.Length - 1] - '0';
            int countDigits = 0;
            foreach (char digit in i_str)
            {
                if (digit - '0' > unitsDigit)
                {
                    countDigits++;
                }
            }

            return countDigits;
        }

        public static int FindSmallestDigit(string i_str)
        {
            int minDigit = i_str[0] - '0';
            foreach (char digit in i_str)
            {
                if (digit - '0' < minDigit)
                {
                    minDigit = digit - '0';
                }
            }

            return minDigit;
        }

        public static int FindNumOfDigitsDividedByThree(string i_str)
        {

            int countDigits = 0;
            foreach (char digit in i_str)
            {
                if ((digit - '0') % 3 == 0)
                {
                    countDigits++;
                }
            }

            return countDigits;
        }

        public static float FindAvgOfDigits(string i_str)
        {
            float sumDigits = 0;
            foreach (char digit in i_str)
            {
                sumDigits += (digit - '0');
            }

            return sumDigits / i_str.Length;
        }
    }
}
