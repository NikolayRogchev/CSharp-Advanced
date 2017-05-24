using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StacksAndQueues
{
    class ReverseStrings
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> result = new Stack<char>();
            foreach (char symbol in input)
            {
                result.Push(symbol);
            }

            while (result.Count != 0)
            {
                Console.Write(result.Pop());
            }
            Console.WriteLine();
        }
    }
}
