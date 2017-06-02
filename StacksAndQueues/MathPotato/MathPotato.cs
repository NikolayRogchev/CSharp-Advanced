using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPotato
{
    class MathPotato
    {
        static void Main(string[] args)
        {
            List<string> children = new List<string>(Console.ReadLine().Split(' '));
            int step = int.Parse(Console.ReadLine());
            Queue<string> removedChildren = new Queue<string>();
            int index = (step - 1) % children.Count;
            int cycle = 1;
            while (children.Count > 1)
            {
                if (IsPrime(cycle))
                {
                    removedChildren.Enqueue("Removed " + children[index]);
                    children.RemoveAt(index);
                }
                else
                {
                    removedChildren.Enqueue("Prime " + children[index]);
                }
                index = (index + step - 1) % children.Count;
                cycle++;
            }
            while (removedChildren.Count > 0)
            {
                Console.WriteLine(removedChildren.Dequeue());
            }
            Console.WriteLine("Last is " + children[0]);
        }

        static bool IsPrime(int num)
        {
            for (int i = 2; i < Math.Sqrt(num); i++)
            {
                if (num / i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
