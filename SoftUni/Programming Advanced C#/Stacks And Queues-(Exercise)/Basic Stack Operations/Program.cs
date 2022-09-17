using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = elements[0];
            int numToRemove = elements[1];
            int numToSearch = elements[2];

            Stack<int> stack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            for (int i = 0; i < numToRemove; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(numToSearch))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(stack.Count);
            }
        }
    }
}
