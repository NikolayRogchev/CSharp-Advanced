using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class Calculator
    {
        static void Main(string[] args)
        {
            string equasion = Console.ReadLine();
            Stack<string> parts = new Stack<string>(equasion.Split(' ').Reverse());
            double result = 0;
            string operation = "+";

            while (parts.Count > 0)
            {
                string currentItem = parts.Pop();
                double currentDigit = 0;
                if (double.TryParse(currentItem, out currentDigit))
                {
                    if (operation == "+")
                    {
                        result += currentDigit;
                    }
                    else
                    {
                        result -= currentDigit;
                    }
                }
                else
                {
                    operation = currentItem;
                }
            }
            Console.WriteLine(result);
        }
    }
}
