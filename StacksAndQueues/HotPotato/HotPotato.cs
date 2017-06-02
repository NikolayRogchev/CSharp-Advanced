using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotPotato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            List<string> children = new List<string>(Console.ReadLine().Split(' '));
            int step = int.Parse(Console.ReadLine());
            Queue<string> removedChildren = new Queue<string>();
            int index = (step - 1) % children.Count;
            while (children.Count > 1)
            {
                removedChildren.Enqueue(children[index]);
                children.RemoveAt(index);
                index = (index + step - 1) % children.Count;
            }
            while (removedChildren.Count > 0)
            {
                Console.WriteLine("Removed " + removedChildren.Dequeue());
            }
            Console.WriteLine("Last is " + children[0]);
        }
    }
}
