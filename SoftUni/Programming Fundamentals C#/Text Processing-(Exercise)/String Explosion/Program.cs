using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int explosion = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char currChar = input[i];
                if (currChar == '>')
                {
                    explosion += int.Parse(input[i + 1].ToString());
                    sb.Append(currChar);
                }
                else if (explosion == 0)
                {
                    sb.Append(currChar);
                }
                else
                {
                    explosion--;
                }
            }
            Console.WriteLine(sb);
        }

    }

}
