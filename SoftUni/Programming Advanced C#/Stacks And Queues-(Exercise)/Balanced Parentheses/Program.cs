using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced_Parentheses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string parenthesis = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            

            foreach (var ch in parenthesis)
            {
                if (stack.Any())
                {
                    char check = stack.Peek();
                    if (check == '(' && ch == ')')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '[' && ch == ']')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (check == '{' && ch == '}')
                    {
                        stack.Pop();
                        continue;
                    }
                }

                stack.Push(ch);
            }

            if (stack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
