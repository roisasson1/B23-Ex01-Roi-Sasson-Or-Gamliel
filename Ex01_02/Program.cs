namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            PrintDiamondOnScreen();
        }

        public static void PrintDiamondOnScreen()
        {
            int diamondHeight = 9;
            UpperPartOfDiamond(diamondHeight, 0);
            LowerPartOfDiamond(diamondHeight, 1);
        }

        public static void UpperPartOfDiamond(int i_diamondHeight, int i_currentDiamondHeight)
        {
            if (i_currentDiamondHeight > i_diamondHeight) // base case 
            {
                return;
            }

            AddSpaceInDiamond(i_diamondHeight, i_currentDiamondHeight, -1);
            if (i_currentDiamondHeight % 2 == 0)
            {
                i_currentDiamondHeight++;
            }

            MoveTonextLine(0, i_currentDiamondHeight, 1);
            System.Console.Write("\n");

            UpperPartOfDiamond(i_diamondHeight, i_currentDiamondHeight + 1);

        }

        public static void LowerPartOfDiamond(int i_diamondHeight, int i_currentDiamondHeight)
        {
            if (i_currentDiamondHeight >= i_diamondHeight) // base case 
            {
                return;
            }

            if (i_currentDiamondHeight % 2 == 0)
            {
                i_currentDiamondHeight++;
            }

            AddSpaceInDiamond(0, i_currentDiamondHeight + 2, 1);
            MoveTonextLine(i_diamondHeight - 1, i_currentDiamondHeight, -1);
            System.Console.Write("\n");
            LowerPartOfDiamond(i_diamondHeight, i_currentDiamondHeight + 2);
        }

        public static void MoveTonextLine(int i_lineOfDiamond, int i_currentHeight, int i_direction)
        {
            if (i_lineOfDiamond == i_currentHeight) // base case 
            {
                return;
            }

            System.Console.Write("* ");
            MoveTonextLine(i_lineOfDiamond + i_direction, i_currentHeight, i_direction);
        }

        public static void AddSpaceInDiamond(int i_start, int i_end, int i_howManySpacesToAdd)
        {
            if (i_start == i_end) // base case
            {
                return;
            }

            System.Console.Write(" ");
            AddSpaceInDiamond(i_start + i_howManySpacesToAdd, i_end, i_howManySpacesToAdd);
        }
    }
}
