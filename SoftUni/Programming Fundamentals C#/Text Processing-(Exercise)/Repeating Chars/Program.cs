using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repeating_Chars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sentance = Console.ReadLine();
            char currChar = '\0';
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < sentance.Length; i++)
            {
                if (sentance[i] != currChar)
                {
                    sb.Append(sentance[i]);
                    currChar = sentance[i];
                }
            }
            Console.WriteLine(sb);
        }
    }
}
