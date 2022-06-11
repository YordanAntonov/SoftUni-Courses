using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepeatString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int repeat = int.Parse(Console.ReadLine());
            string ressult = CreateString(word, repeat);
            Console.WriteLine(ressult);
        }

        static string CreateString(string word, int repeat)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < repeat; i++)
            {
                result.Append(word);
            }
            return result.ToString();
        }
    }
}
