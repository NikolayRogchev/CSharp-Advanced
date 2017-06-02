using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            double[][] matrix = new double[size][];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
            }
            Console.WriteLine(Math.Abs(MainDiagonalSum(matrix) - SecondaryDiagonalSum(matrix)));
        }

        static double MainDiagonalSum(double[][] matrix)
        {
            double result = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                result += matrix[i][i];
            }
            return result;
        }

        static double SecondaryDiagonalSum(double[][] matrix)
        {
            double result = 0;
            int size = matrix.GetLength(0);
            for (int i = 0; i < size; i++)
            {
                result += matrix[size - 1 - i][i];
            }
            return result;
        }
    }
}
