using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matching_Brackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> indexStack = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    indexStack.Push(i);
                    continue;
                }
                
                if (expression[i] == ')')
                {
                    int startIndex = indexStack.Pop();
                    Console.WriteLine(expression.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
