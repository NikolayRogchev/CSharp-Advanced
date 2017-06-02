using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixOfPalindromes
{
    class MatrixOfPalindromes
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            for (int row = 0; row < rows; row++)
            {
                char startLetter = (char)('a' + row);
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{startLetter}{(char)(startLetter + col)}{startLetter} ");
                }
                Console.WriteLine();
            }
        }
    }
}
