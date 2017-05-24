using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalToBinary
{
    class DecimalToBinary
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            Stack<int> result = new Stack<int>();
            if (number == 0)
            {
                Console.WriteLine(0);
                return;
            }
            while (number > 0)
            {
                result.Push(number % 2);
                number /= 2;
            }

            while (result.Count > 0)
            {
                Console.Write(result.Pop());
            }
            Console.WriteLine();
        }
    }
}
