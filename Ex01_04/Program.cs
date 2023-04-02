using System;
using System.Linq;
using System.Text;

class Program
{
    public static void Main()
    {
        Console.WriteLine(MessageToScreen());
    }

    public static StringBuilder MessageToScreen()
    {
        Console.WriteLine("Hello, please enter a 6 character string:");
        string userStr = ReadStrFromUser(out bool isANumber);
        StringBuilder message = new StringBuilder();
        message.AppendLine($"The string is {(IsPalindrome(userStr) ? "" : "not ")}a palindrome.");
        if (isANumber)
        {
            message.AppendLine($"The number is {(IsDividedBy3(userStr) ? "" : "not ")}divided by 3.");
        }
        else
        {
            int numOfUpperLetters = CountUpperLetters(userStr);
            message.AppendFormat("The word has {0} upper letter{1}.\n", numOfUpperLetters, numOfUpperLetters > 1 ? "s" : "");
        }
        return message;
    }

    public static bool IsPalindrome(string i_usreStr)
    {
        if (i_usreStr.Length == 0 || i_usreStr.Length == 1)
        {
            return true;
        }
        else
        {
            if (i_usreStr[0] != i_usreStr[i_usreStr.Length - 1])
            {
                return false;
            }
            else
            {
                return IsPalindrome(i_usreStr.Substring(1, i_usreStr.Length - 2));
            }
        }
    }
    public static bool IsDividedBy3(string i_usreStr)
    {
        int.TryParse(i_usreStr, out int num);
        return num % 3 == 0;
    }
    public static int CountUpperLetters(string i_userStr)
    {
        int numOfUpperLetters = 0;

        for (int i = 0; i < i_userStr.Length; i++)
        {
            if (char.IsUpper(i_userStr[i])) numOfUpperLetters++;
        }
        return numOfUpperLetters;
    }
    public static string ReadStrFromUser(out bool io_isANumber)
    {
        string userStr = Console.ReadLine();

        while (!IsValid(userStr, out io_isANumber))
        {
            System.Console.WriteLine("The string is invalid! try again:");
            userStr = System.Console.ReadLine();
        }
        return userStr;
    }
    public static bool IsValid(string i_str, out bool io_isNumber)
    {
        bool valid = false;
        io_isNumber = i_str.All(char.IsDigit);
        bool isAllLetters = i_str.All(char.IsLetter);

        valid = ((io_isNumber || isAllLetters) && i_str.Length == 6);

        /*if ((io_isNumber || isAllLetters) && i_str.Length == 6)
        {
            valid = true;
        }*/
        return valid;
    }
}