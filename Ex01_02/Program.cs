namespace Ex01_02
{
    public class Program
    {
        public static void Main()
        {
            makeDiamond();
        }

        public static void makeDiamond()
        {
            int diamondHeight = 9;
            upperPartOfDiamond(diamondHeight, 0);
            lowerPartOfDiamond(diamondHeight, 1);
        }

        public static void upperPartOfDiamond(int i_diamondHeight, int i_currentDiamondHeight)
        {
            if (i_currentDiamondHeight > i_diamondHeight)
            {
                return;
            }

            addSpaceInDiamond(i_diamondHeight, i_currentDiamondHeight, -1);
            if (i_currentDiamondHeight % 2 == 0)
            {
                i_currentDiamondHeight++;
            }
            moveTonextLine(0, i_currentDiamondHeight, 1);
            System.Console.Write("\n");

            upperPartOfDiamond(i_diamondHeight, i_currentDiamondHeight + 1);

        }

        public static void lowerPartOfDiamond(int i_diamondHeight, int i_currentDiamondHeight)
        {
            if (i_currentDiamondHeight >= i_diamondHeight)
            {
                return;
            }
            if (i_currentDiamondHeight % 2 == 0)
            {
                i_currentDiamondHeight++;
            }
            addSpaceInDiamond(0, i_currentDiamondHeight + 2, 1);
            moveTonextLine(i_diamondHeight - 1, i_currentDiamondHeight, -1);
            System.Console.Write("\n");
            lowerPartOfDiamond(i_diamondHeight, i_currentDiamondHeight + 2);
        }

        public static void moveTonextLine(int i_lineOfDiamond, int k, int z)
        {
            if (i_lineOfDiamond == k)
            {
                return;
            }
            System.Console.Write("* ");
            moveTonextLine(i_lineOfDiamond + z, k, z);
        }

        public static void addSpaceInDiamond(int j, int k, int i_howManySpacesToAdd)
        {
            if (j == k) // Base case
            {
                return;
            }
            System.Console.Write(" ");
            addSpaceInDiamond(j + i_howManySpacesToAdd, k, i_howManySpacesToAdd);
        }
    }
}
