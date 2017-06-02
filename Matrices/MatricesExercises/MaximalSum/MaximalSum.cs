using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximalSum
{
    class MaximalSum
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            int[][] matrix = ReadMatrix(rows);
            int maxSum = int.MinValue;
            int[][] maxSumSubMatrix = new int[3][];
            int maxSumSubMatrixStartRow = -1;
            int maxSumSubMatrixStartCol = -1;
            for (int row = 0; row <= rows - 3; row++)
            {
                for (int col = 0; col <= cols - 3; col++)
                {
                    int currentSum = GetSubMatrixSum(matrix, row, col);
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxSumSubMatrixStartRow = row;
                        maxSumSubMatrixStartCol = col;
                    }
                }
            }
            Console.WriteLine("Sum = " + maxSum);
            PrintMaxSubMatrix(matrix, maxSumSubMatrixStartRow, maxSumSubMatrixStartCol);
        }

        private static int[][] ReadMatrix(int rows)
        {
            int[][] resultMatrix = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                resultMatrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            }
            return resultMatrix;
        }

        private static int GetSubMatrixSum(int[][] matrix, int startRow, int startCol)
        {
            int result = 0;
            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    result += matrix[row][col];
                }
            }
            return result;
        }

        private static void PrintMaxSubMatrix(int[][]matrix, int startRow, int startCol)
        {
            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    string currentNumber = matrix[row][col].ToString() + (col < startCol + 2 ? " " : "");
                    Console.Write(currentNumber);
                }
                Console.WriteLine();
            }
        }
    }
}
