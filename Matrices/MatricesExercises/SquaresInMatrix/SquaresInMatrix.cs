using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresInMatrix
{
    class SquaresInMatrix
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            char[][] matrix = ReadMatrix(rows);
            int equalSubMatrixCount = 0;
            for (int row = 0; row <= rows - 2; row++)
            {
                for (int col = 0; col <= cols - 2; col++)
                {
                    if (ContainsEqualChars(matrix, row, col))
                    {
                        equalSubMatrixCount++;
                    }
                }
            }
            Console.WriteLine(equalSubMatrixCount);
        }

        private static char[][] ReadMatrix(int rows)
        {
            char[][] resultMatrix = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                resultMatrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => Convert.ToChar(x)).ToArray();
            }
            return resultMatrix;
        }

        private static bool ContainsEqualChars(char[][] matrix, int startRow, int startCol)
        {
            bool result = true;
            char startChar = matrix[startRow][startCol];
            for (int row = startRow; row < startRow + 2; row++)
            {
                for (int col = startCol; col < startCol + 2; col++)
                {
                    if (matrix[row][col] != startChar)
                    {
                        result = false;
                        return result;
                    }
                }
            }
            return result;
        }
    }
}
