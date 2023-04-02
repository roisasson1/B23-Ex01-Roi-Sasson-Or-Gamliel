namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            System.Console.WriteLine("Please select the height of the diamond: ");
            string outputNumber = readNumber();
            makeDiamond(outputNumber);
        }

        public static void makeDiamond(string i_output)
        {
            int diamondHeight = int.Parse(i_output);
            if (diamondHeight % 2 == 0)
            {
                diamondHeight--;
            }
            Ex01_02.Program.upperPartOfDiamond(diamondHeight, 0);
            Ex01_02.Program.lowerPartOfDiamond(diamondHeight, 1);
        }

        public static string readNumber()
        {
            string outputNumber = System.Console.ReadLine();
            while (!checkValidity(outputNumber))
            {
                System.Console.WriteLine("The number is invalid! try again:");
                outputNumber = System.Console.ReadLine();
                if (checkValidity(outputNumber))
                    continue;
            }
            return outputNumber;
        }

        public static bool checkValidity(string i_binaryNum)
        {
            bool valid = true;
            if (i_binaryNum.Length <= 0)
            {
                valid = false;
            }
            return valid;
        }
    }
}
