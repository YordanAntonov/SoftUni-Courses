using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine().ToLower();
            int result = CountVowels(word);
            Console.WriteLine(result);

        }

        static int CountVowels(string word)
        {
            int count = 0;
            foreach (char letter in word)
            {
                if ("aouei".Contains(letter))
                {
                    count++;
                }
            }
            return count;
        }
    }
}
