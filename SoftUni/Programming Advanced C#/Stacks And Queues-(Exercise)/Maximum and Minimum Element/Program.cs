using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfQueries = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numOfQueries; i++)
            {
                int[] query = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int cmdNum = query[0];

                if (cmdNum == 1)
                {
                    int elementToPush = query[1];
                    stack.Push(elementToPush);
                }
                else if (cmdNum == 2)
                {
                    stack.Pop();
                }
                else if (cmdNum == 3)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Max());
                    }
                }
                else if (cmdNum == 4)
                {
                    if (stack.Any())
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
