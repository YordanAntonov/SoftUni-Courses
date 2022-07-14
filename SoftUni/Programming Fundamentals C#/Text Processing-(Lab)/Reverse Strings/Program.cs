using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            while (true)
            {
                StringBuilder sb = new StringBuilder();
                if (word == "end")
                {
                    break;
                }

                for (int i = word.Length - 1; i >= 0; i--)
                {
                    sb.Append(word[i]);
                }
                Console.WriteLine($"{word} = {sb}");

                word = Console.ReadLine();
            }

        }
    }
}
