using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioactiveBunnies
{
    class RadioactiveBunnies
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int rows = int.Parse(input[0]);
            int cols = int.Parse(input[1]);
            char[][] matrix = FillMatrix(rows);
            //PrintMatrix(matrix);
            char[] commands = Console.ReadLine().ToCharArray();
            Tuple<int, int> playerPos = FindPlayer(matrix);
            bool isAlive = true;

            foreach (char command in commands)
            {
                Tuple<bool, bool> resultAfterTurn = TryMovePlayer(command, matrix, playerPos);
                isAlive = resultAfterTurn.Item1;
                bool hasWon = resultAfterTurn.Item2;
                SpreadBunnies(matrix);
                if (!isAlive)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"Dead: {playerPos.Item1} {playerPos.Item2}");
                    break;
                }
                if (hasWon)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"Won: {playerPos.Item1} {playerPos.Item2}");
                    break;
                }
                playerPos = UpdatePlayerPosition(command, playerPos, matrix);
            }
        }

        private static Tuple<int, int> UpdatePlayerPosition(char command, Tuple<int, int> playerPos, char[][] matrix)
        {
            int row = playerPos.Item1;
            int col = playerPos.Item2;
            matrix[row][col] = '.';
            switch (command)
            {
                case 'L':
                    col--;
                    break;
                case 'R':
                    col++;
                    break;
                case 'U':
                    row--;
                    break;
                case 'D':
                    row++;
                    break;
            }
            matrix[row][col] = 'P';
            return Tuple.Create(row, col);
        }

        private static Tuple<bool, bool> TryMovePlayer(char command, char[][] matrix, Tuple<int, int> playerPos)
        {
            bool hasWon;
            bool hasCollidedWithBunny = HasCollidedWithBunny(matrix, command, playerPos, out hasWon);
            int row = playerPos.Item1;
            int col = playerPos.Item2;
            if (!hasCollidedWithBunny && !hasWon)
            {
                switch (command)
                {
                    case 'L':
                        matrix[row][col - 1] = 'B';
                        break;
                    case 'R':
                        matrix[row][col + 1] = 'B';
                        break;
                    case 'U':
                        matrix[row - 1][col] = 'B';
                        break;
                    case 'D':
                        matrix[row + 1][col] = 'B';
                        break;
                }
            }
            return Tuple.Create(hasCollidedWithBunny, hasWon);
        }

        private static bool HasCollidedWithBunny(char[][] matrix, char command, Tuple<int, int> playerPos, out bool hasWon)
        {
            bool hasCollided = false;
            int row = playerPos.Item1;
            int col = playerPos.Item2;
            try
            {
                switch (command)
                {
                    case 'L':
                        if (matrix[row][col - 1] == 'B')
                        {
                            hasCollided = true;
                        }
                        break;
                    case 'R':
                        if (matrix[row][col + 1] == 'B')
                        {
                            hasCollided = true;
                        }
                        break;
                    case 'U':
                        if (matrix[row - 1][col] == 'B')
                        {
                            hasCollided = true;
                        }
                        break;
                    case 'D':
                        if (matrix[row + 1][col] == 'B')
                        {
                            hasCollided = true;
                        }
                        break;
                }
            }
            catch (IndexOutOfRangeException e)
            {
                hasWon = true;
                return hasCollided;
            }
            hasWon = false;
            return hasCollided;
        }

        private static void SpreadBunnies(char[][] matrix)
        {
            char[][] oldMatrix = new char[matrix.GetLength(0)][];
            Queue<Tuple<int, int>> bunnyPositions = GetBunnyPositions(matrix);

            while (bunnyPositions.Count > 0)
            {
                Tuple<int, int> currentBunnyPos = bunnyPositions.Dequeue();
                int row = currentBunnyPos.Item1;
                int col = currentBunnyPos.Item2;
                SpreadBunny(matrix, row, col);
            }
        }

        private static Queue<Tuple<int, int>> GetBunnyPositions(char[][] matrix)
        {
            Queue<Tuple<int, int>> bunnyPositions = new Queue<Tuple<int, int>>();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'B')
                    {
                        bunnyPositions.Enqueue(Tuple.Create(row, col));
                    }
                }
            }
            return bunnyPositions;
        }

        private static void SpreadBunny(char[][] matrix, int row, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix[row].Length;
            if (row - 1 >= 0)
            {
                matrix[row - 1][col] = 'B';
            }
            if (row + 1 < rows)
            {
                matrix[row + 1][col] = 'B';
            }
            if (col - 1 >= 0)
            {
                matrix[row][col - 1] = 'B';
            }
            if (col + 1 < cols)
            {
                matrix[row][col + 1] = 'B';
            }

            Console.WriteLine("--------------------------------------");
            PrintMatrix(matrix);
        }

        static Tuple<int, int> FindPlayer(char[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 'P')
                    {
                        return Tuple.Create(row, col);
                    }
                }
            }
            return null;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine(string.Join("", matrix[i]));
            }
        }

        private static char[][] FillMatrix(int rows)
        {
            char[][] result = new char[rows][];
            for (int i = 0; i < rows; i++)
            {
                result[i] = Console.ReadLine().ToCharArray();
            }
            return result;
        }
    }
}
