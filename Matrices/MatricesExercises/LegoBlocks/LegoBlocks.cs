using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoBlocks
{
    class LegoBlocks
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            string[][] firstBlock = new string[rows][];
            string[][] secondBlock = new string[rows][];
            int firstBlockCellsCount = FillBlock(firstBlock);
            int secondBlockCellsCount = FillBlock(secondBlock);
            bool areBlocksPerfectFit = CheckIfBlocksFit(firstBlock, secondBlock);

            if (areBlocksPerfectFit)
            {
                char[][] resultBlock = CombineBlocks(firstBlock, secondBlock);
                PrintResultMatrix(resultBlock);
            }
            else
            {
                Console.WriteLine("The total number of cells is: {0}",  firstBlockCellsCount + secondBlockCellsCount);
            }
        }

        private static void PrintResultMatrix(char[][] resultBlock)
        {
            for (int i = 0; i < resultBlock.GetLength(0); i++)
            {
                Console.WriteLine("[" + string.Join(", ", resultBlock[i]) + "]");
            }
        }

        private static char[][] CombineBlocks(string[][] firstBlock, string[][] secondBlock)
        {
            char[][] result = new char[firstBlock.GetLength(0)][];
            for (int row = 0; row < result.GetLength(0); row++)
            {
                result[row] = (string.Join("",firstBlock[row]) + string.Join("", secondBlock[row].Reverse())).ToCharArray();
            }
            return result;
        }

        private static bool CheckIfBlocksFit(string[][] firstBlock, string[][] secondBlock)
        {
            bool result = true;
            int totalSize = firstBlock[0].Length + secondBlock[0].Length;
            for (int row = 1; row < firstBlock.GetLength(0); row++)
            {
                if (firstBlock[row].Length + secondBlock[row].Length != totalSize)
                {
                    result = false;
                    break;
                }
            }
            return result;
        }

        private static int FillBlock(string[][] block)
        {
            int result = 0;
            for (int i = 0; i < block.GetLength(0); i++)
            {
                block[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                result += block[i].Length;
            }
            return result;
        }
    }
}
