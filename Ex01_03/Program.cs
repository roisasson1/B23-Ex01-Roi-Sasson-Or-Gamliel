namespace Ex01_03
{
    public class Program
    {
        public static void Main()
        {
            System.Console.WriteLine("Please select the height of the diamond: ");
            string outputNumber = ReadNumber();
            MakeDiamond(outputNumber);
        }

        public static void MakeDiamond(string i_output)
        {
            int diamondHeight = int.Parse(i_output);

            if (diamondHeight % 2 == 0)
            {
                diamondHeight--;
            }

            Ex01_02.Program.UpperPartOfDiamond(diamondHeight, 0);
            Ex01_02.Program.LowerPartOfDiamond(diamondHeight, 1);
        }

        public static string ReadNumber()
        {
            string outputNumber = System.Console.ReadLine();

            while (!CheckValidity(outputNumber))
            {
                System.Console.WriteLine("The number is invalid! try again:");
                outputNumber = System.Console.ReadLine();
                if (CheckValidity(outputNumber))
                    continue;
            }

            return outputNumber;
        }

        public static bool CheckValidity(string i_binaryNum)
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
