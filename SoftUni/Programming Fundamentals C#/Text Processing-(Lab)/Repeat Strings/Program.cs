using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repeat_Strings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            foreach (string word in words)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    Console.Write(word);
                }
            }
        }
    }
}
