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
            List<string> children = "Gosho Pesho Misho Stefan Krasi".Split(' ').ToList();// new List<string>(Console.ReadLine().Split(' '));
            int step = 10;// int.Parse(Console.ReadLine());
            Queue<string> removedChildren = new Queue<string>();
            while (children.Count > 1)
            {
                int index = (step - 1) % children.Count;
                removedChildren.Enqueue(children[index]);
                children.RemoveAt(index);
            }
            while (removedChildren.Count > 0)
            {
                Console.WriteLine("Removed " + removedChildren.Dequeue());
            }
            Console.WriteLine("Last is " + children[0]);
        }
    }
}
