using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes
{
    class Snakes
    {
        static void Main(string[] args)
        {
            string matrixData = Console.ReadLine();
            int rows = int.Parse(matrixData.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]);
            int cols = int.Parse(matrixData.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            string snake = Console.ReadLine();
            int[] shootData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int impactRow = shootData[0];
            int impactCol = shootData[1];
            int radius = shootData[2];

            char[,] matrix = FillMatrix(snake, rows, cols);
            Shoot(matrix, impactRow, impactCol, radius);
            FormatMatrixAfterBlast(matrix);
            PrintMatrix(matrix);
        }

        private static void FormatMatrixAfterBlast(char[,] matrix)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                FormatSingleColumn(matrix, col);
            }
        }

        private static void FormatSingleColumn(char[,] matrix, int targetCol)
        {
            int rowIndex = matrix.GetLength(0) - 1;
            while (rowIndex > 0)
            {
                char currentSymbol = matrix[rowIndex, targetCol];
                if (currentSymbol == ' ')
                {
                    Queue<char> fallingSymbols = new Queue<char>();
                    for (int row = rowIndex; row >= 0; row--)
                    {
                        if (matrix[row, targetCol] != ' ')
                        {
                            for (int i = row; i >= 0; i--)
                            {
                                fallingSymbols.Enqueue(matrix[i, targetCol]);
                                matrix[i, targetCol] = ' ';
                            }
                            break;
                        }
                    }
                    while (fallingSymbols.Count > 0)
                    {
                        matrix[rowIndex, targetCol] = fallingSymbols.Dequeue();
                        rowIndex--;
                    }
                    break;
                }
                rowIndex--;
            }
        }

        private static void Shoot(char[,] matrix, int impactRow, int impactCol, int radius)
        {
            if (radius > 0)
            {
                int innerBlastStartRow = impactRow - radius + 1;
                int innerBlastStartCol = impactCol - radius + 1;
                for (int row = innerBlastStartRow; row < innerBlastStartRow + radius + 1; row++)
                {
                    for (int col = innerBlastStartCol; col < innerBlastStartCol + radius + 1; col++)
                    {
                        try
                        {
                            matrix[row, col] = ' ';
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            continue;
                        }
                    }
                }

                if (impactCol - radius >= 0)
                {
                    matrix[impactRow, impactCol - radius] = ' ';
                }
                if (impactCol + radius <= matrix.GetLength(0))
                {
                    matrix[impactRow, impactCol + radius] = ' ';
                }
                if (impactRow - radius >= 0)
                {
                    matrix[impactRow - radius, impactCol] = ' ';
                }
                if (impactRow + radius <= matrix.GetLength(1))
                {
                    matrix[impactRow + radius, impactCol] = ' ';
                }
            }
            else
            {
                matrix[impactRow, impactCol] = ' ';
            }
        }
        private static char[,] FillMatrix(string snake, int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];
            string direction = "left";
            int snakeIndexCounter = 0;
            for (int row = rows - 1; row >= 0; row--)
            {
                if (direction == "left")
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake[snakeIndexCounter % snake.Length];
                        snakeIndexCounter++;
                    }
                    direction = "right";
                }
                else
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snake[snakeIndexCounter % snake.Length];
                        snakeIndexCounter++;
                    }
                    direction = "left";
                }
            }
            return matrix;
        }
        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
