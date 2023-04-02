using System;
public class Program
{
    public static void Main()
    {
        string message = ReadThreeBinaryNumbers();
        System.Console.WriteLine(message);
    }

    public static string ReadThreeBinaryNumbers()
    {
        string binaryNum;
        int decimalNum;
        int firstDecimalNum = 0;
        int secondDecimalNum = 0;
        int thirdDecimalNum = 0;
        int maxNumOfZeros = 24;
        float sumOfZeros = 0;
        float sumOfOnes;
        int dividedByFour = 0;
        int decreasingSet = 0;
        int palindrom = 0;

        Console.WriteLine("Hello, Please enter three binary numbers with 8 digits each:");

        for (int i = 1; i <= 3; i++)
        {
            binaryNum = ReadBinaryNumber();
            int numOfZeros = FindNumOfZeros(binaryNum);
            sumOfZeros += numOfZeros;
            decimalNum = ConvertBinaryToDecimal(binaryNum);

            if (i == 1)
            {
                firstDecimalNum = decimalNum;
            }
            else if (i == 2)
            {
                secondDecimalNum = decimalNum;
            }
            else
            {
                thirdDecimalNum = decimalNum;
            }

            if (IsDividedByFour(decimalNum))
            {
                dividedByFour++;
            }
            if (IsDecreasingSet(decimalNum))
            {
                decreasingSet++;
            }
            if (IsPalindrome(decimalNum))
            {
                palindrom++;
            }
        }
        sumOfOnes = maxNumOfZeros - sumOfZeros;

        PrintInDescendingOrder(firstDecimalNum, secondDecimalNum, thirdDecimalNum);

        float avgOfZeros = sumOfZeros / 3;
        float avgOfOnes = sumOfOnes / 3;
        return MessageToScreen(avgOfZeros, avgOfOnes, dividedByFour, decreasingSet, palindrom);
    }

    public static void PrintInDescendingOrder(int i_firstDecimalNum, int i_secondDecimalNum, int i_thirdDecimalNum)
    {
        if (i_firstDecimalNum < i_secondDecimalNum)
        {
            int temp = i_firstDecimalNum;
            i_firstDecimalNum = i_secondDecimalNum;
            i_secondDecimalNum = temp;
        }
        if (i_secondDecimalNum < i_thirdDecimalNum)
        {
            int temp = i_secondDecimalNum;
            i_secondDecimalNum = i_thirdDecimalNum;
            i_thirdDecimalNum = temp;
        }
        if (i_firstDecimalNum < i_secondDecimalNum)
        {
            int temp = i_firstDecimalNum;
            i_firstDecimalNum = i_secondDecimalNum;
            i_secondDecimalNum = temp;
        }
        Console.WriteLine("{0}, {1}, {2}", i_firstDecimalNum, i_secondDecimalNum, i_thirdDecimalNum);
    }

    public static string ReadBinaryNumber()
    {
        bool isValid = false;
        string binaryNum = System.Console.ReadLine();
        while (!isValid)
        {
            if (CheckValidity(binaryNum))
            {
                isValid = true;
            }
            else
            {
                System.Console.WriteLine("The number is invalid! try again:");
                binaryNum = System.Console.ReadLine();
            }
        }
        return binaryNum;
    }

    public static bool CheckValidity(string i_binaryNum)
    {
        if (i_binaryNum.Length != 8)
        {
            return false;
        }
        for (int i = 0; i < 8; i++)
        {
            if (i_binaryNum[i] != '0' && i_binaryNum[i] != '1')
                return false;
        }
        return true;
    }

    public static int ConvertBinaryToDecimal(string i_BinaryNumber)
    {
        int decimalNumber = 0;
        for (int i = i_BinaryNumber.Length - 1; i >= 0; i--)
        {
            if (i_BinaryNumber[i] == '1')
            {
                decimalNumber += System.Convert.ToInt16(System.Math.Pow(2, i_BinaryNumber.Length - i - 1) * (i_BinaryNumber[i] - '0'));
            }
        }
        return decimalNumber;
    }

    public static int FindNumOfZeros(string i_number)
    {
        int sumOfZeros = 0;
        for (int i = i_number.Length - 1; i >= 0; i--)
        {
            if (i_number[i] == '0')
            {
                sumOfZeros++;
            }
        }
        return sumOfZeros;
    }
    public static bool IsDividedByFour(int i_decimalNumber)
    {
        bool dividedByFour = false;
        if (i_decimalNumber % 4 == 0)
        {
            dividedByFour = true;
        }
        return dividedByFour;
    }

    public static bool IsDecreasingSet(int i_decimalNumber)
    {
        bool decreasingSet = true;
        string decimalNumberAsString = i_decimalNumber.ToString();
        for (int i = 0; i < decimalNumberAsString.Length - 1; i++)
        {
            if (decimalNumberAsString[i] <= decimalNumberAsString[i + 1])
            {
                decreasingSet = false;
                break;
            }
        }
        return decreasingSet;
    }

    public static bool IsPalindrome(int i_decimalNumber)
    {
        bool palindrom = true;
        string decimalNumberAsString = i_decimalNumber.ToString();
        int length = decimalNumberAsString.Length;
        for (int i = 0; i < length / 2; i++)
        {
            if (decimalNumberAsString[i] != decimalNumberAsString[length - i - 1])
            {
                palindrom = false;
                break;
            }
        }
        return palindrom;
    }

    public static string MessageToScreen(float i_avgOfZeros, float i_avgOfOnes, int i_dividedByFour, int i_decreasingSet, int i_palindrom)
    {
        return string.Format(
    @"The average number of 0's is: {0}.
The average number of 1's is: {1}.
The amount of numbers which are divided by 4 is: {2}
The amount of numbers which their digits are arranged in a strictly decreasing order is: {3}
The amount of numbers which are a palindrom is: {4}"
              , i_avgOfZeros, i_avgOfOnes, i_dividedByFour, i_decreasingSet, i_palindrom);
    }
}