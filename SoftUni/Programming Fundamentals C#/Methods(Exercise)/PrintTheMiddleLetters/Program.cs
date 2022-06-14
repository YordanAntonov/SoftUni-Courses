using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintTheMiddleLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            CheckMiddle(word);
        }
        static void CheckMiddle(string word)
        {
            if(word.Length % 2 == 0)
            {
                Console.Write(word[(word.Length / 2) - 1]);
                Console.WriteLine(word[word.Length / 2]);
            }
            else
            {
                Console.WriteLine(word[word.Length / 2]);
            }
        }
    }
}
