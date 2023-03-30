using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program
{
    public static void Main()
    {
        string binaryNum;
        int decimalNum;
        int sumOfZeros = 0;
        int sumOfOnes = 0;
        int dividedByFour = 0;
        int decreasingSet = 0;
        int palindrom = 0;
        for (int i = 0; i < 3; i++)
        {
            binaryNum = readBinaryNumber();
            decimalNum = convertBinaryToDecimal(binaryNum);
            int numOfZeros = findNumOfZeros(binaryNum);
            sumOfZeros += numOfZeros;
            sumOfOnes += (binaryNum.Length - numOfZeros);
            if (isDividedByFour(decimalNum))
                dividedByFour++;
            if (isDecreasingSet(decimalNum))
                decreasingSet++;
            if (isPalindrom(decimalNum))
                palindrom++;
        }

        // TODO: order by size desc
        // System.Console.WriteLine("The decimal numbers are: ...");

        float avgOfZeros = sumOfZeros / 3;
        float avgOfOnes = sumOfOnes / 3;
        string message = messageToScreen(avgOfZeros, avgOfOnes, dividedByFour, decreasingSet, palindrom);
        System.Console.WriteLine(message);

    }

    public static string readBinaryNumber()
    {
        string binaryNum = System.Console.ReadLine();
        while (!checkValidity(binaryNum))
        {
            System.Console.WriteLine("The number is invalid! try again:");
            binaryNum = System.Console.ReadLine();
            if (checkValidity(binaryNum))
                continue;
        }
        return binaryNum;
    }

    public static bool checkValidity(string i_binaryNum)
    {
        if (i_binaryNum.Length != 8)
            return false;
        for (int i = 0; i < 8; i++)
        {
            if (i_binaryNum[i] != '0' && i_binaryNum[i] != '1')
                return false;
        }
        return true;
    }

    public static int convertBinaryToDecimal(string i_BinaryNumber)
    {
        int decimalNumber = 0;
        for (int i = i_BinaryNumber.Length - 1; i >= 0; i--)
        {
            if (i_BinaryNumber[i] == '1')
            {
                decimalNumber += System.Convert.ToInt32(System.Math.Pow(2, i_BinaryNumber.Length - i - 1) * (i_BinaryNumber[i] - '0'));
            }
        }
        return decimalNumber;
    }

    public static int findNumOfZeros(string i_number)
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
    public static bool isDividedByFour(int i_decimalNumber)
    {
        if (i_decimalNumber % 4 == 0)
            return true;
        return false;
    }

    public static bool isDecreasingSet(int i_decimalNumber)
    {
        string decimalNumberAsString = i_decimalNumber.ToString();
        for (int i = 0; i < decimalNumberAsString.Length - 1; i++)
        {
            if (decimalNumberAsString[i] <= decimalNumberAsString[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    public static bool isPalindrom(int i_decimalNumber)
    {
        string decimalNumberAsString = i_decimalNumber.ToString();
        int length = decimalNumberAsString.Length;
        for (int i = 0; i < length / 2; i++)
        {
            if (decimalNumberAsString[i] != decimalNumberAsString[length - i - 1])
                return false;
        }
        return true;
    }

    public static string messageToScreen(float i_avgOfZeros, float i_avgOfOnes, int i_dividedByFour, int i_decreasingSet, int i_palindrom)
    {
        return string.Format(
@"The average number of 0's is: {0},
The average number of 1's is: {1},
There are {2} numbers divided by 4,
There are {3} numbers that their digits are decreasing set,
There are {4} numbers that their digits are palindrom."
                  , i_avgOfZeros, i_avgOfOnes, i_dividedByFour, i_decreasingSet, i_palindrom);
    }
}
