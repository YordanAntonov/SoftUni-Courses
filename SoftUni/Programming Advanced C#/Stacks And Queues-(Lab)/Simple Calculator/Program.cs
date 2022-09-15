using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> stack = new Stack<string>(input.Reverse());


            int result = int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                if (stack.Pop() == "+")
                {
                    result += int.Parse(stack.Pop());
                }
                else
                {
                    result -= int.Parse(stack.Pop());
                }
            }

            Console.WriteLine(result);
        }
    }
}
