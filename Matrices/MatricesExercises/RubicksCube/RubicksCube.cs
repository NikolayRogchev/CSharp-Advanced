using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubicksCube
{
    class RubicksCube
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int commandsCount = int.Parse(Console.ReadLine());
            int rows = input[0];
            int cols = input[1];
            int[][] matrix = FillMatrix(rows, cols);

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                int targetIndex = int.Parse(command[0]);
                string direction = command[1];
                int movesCount = int.Parse(command[2]);
                ShuffleMatrix(matrix, targetIndex, movesCount, direction);
            }
        }

        private static void ShuffleMatrix(int[][] matrix, int targetIndex, int movesCount, string direction)
        {
            switch (direction)
            {
                case "left":
                    MoveLeft(matrix, targetIndex, movesCount);
                    break;
                case "right":
                    MoveRight(matrix, targetIndex, movesCount);
                    break;
                case "up":
                    MoveUp(matrix, targetIndex, movesCount);
                    break;
                case "down":
                    MoveDown(matrix, targetIndex, movesCount);
                    break;
            }
        }

        private static void MoveDown(int[][] matrix, int targetIndex, int movesCount)
        {
            int size = matrix.GetLength(0);
            int moves = movesCount % size;
            for (int i = 0; i < movesCount; i++)
            {
                int lastElement = matrix[size - 1][targetIndex];
                for (int row = size - 1; row > 0; row--)
                {
                    matrix[row][targetIndex] = matrix[row - 1][targetIndex];
                }
                matrix[0][targetIndex] = lastElement;
            }
        }

        private static void MoveUp(int[][] matrix, int targetIndex, int movesCount)
        {
            int moves = movesCount % matrix.GetLength(0);
            for (int i = 0; i < moves; i++)
            {
                int firstElement = matrix[0][targetIndex];
                for (int row = 0; row < matrix.GetLength(0) - 1; row++)
                {
                    matrix[row][targetIndex] = matrix[row + 1][targetIndex];
                }
                matrix[matrix.GetLength(0)][targetIndex] = firstElement;
            }
        }

        private static void MoveRight(int[][] matrix, int targetIndex, int movesCount)
        {
            int size = matrix.GetLength(1);
            int moves = movesCount % size;
            for (int i = 0; i < moves; i++)
            {
                int firstNumber = matrix[targetIndex][size - 1];
                for (int col = size - 1; col > 0; col--)
                {
                    matrix[targetIndex][col] = matrix[targetIndex][col - 1];
                }
                matrix[targetIndex][size - 1] = firstNumber;
            }
        }

        private static void MoveLeft(int[][] matrix, int targetIndex, int movesCount)
        {
            int size = matrix.GetLength(1);
            int moves = movesCount % size;
            for (int i = 0; i < moves; i++)
            {
                int firstNum = matrix[targetIndex][0];
                for (int col = 0; col < size - 1; col++)
                {
                    matrix[targetIndex][col] = matrix[targetIndex][col + 1];
                }
                matrix[targetIndex][size - 1] = firstNum;
            }
        }

        private static int[][] FillMatrix(int rows, int cols)
        {
            int counter = 1;
            int[][] resultMatrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                resultMatrix[row] = new int[cols];
                for (int col = 0; col < cols; col++)
                {
                    resultMatrix[row][col] = counter;
                    counter++;
                }
            }
            return resultMatrix;
        }
    }
}
