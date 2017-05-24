using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<int> subExpressions = new Stack<int>();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    subExpressions.Push(i);
                }
                if (input[i] == ')')
                {
                    int startIndex = subExpressions.Pop();
                    Console.WriteLine(string.Join("", input.Skip(startIndex).Take(i - startIndex + 1)));
                }
            }
        }
    }
}
