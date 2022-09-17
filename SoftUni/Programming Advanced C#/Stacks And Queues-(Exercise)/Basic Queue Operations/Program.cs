using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = elements[0];
            int numToRemove = elements[1];
            int numToSearch = elements[2];

            Queue<int> queue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            for (int i = 0; i < numToRemove; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(numToSearch))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(queue.Count);
            }
        }
    }
}
