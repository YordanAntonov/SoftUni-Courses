using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStringVol2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            int wordLength = word.Length;
            string reverseWord = "";

            for (int i = wordLength - 1; i >= 0; i--)
            {
                reverseWord += word[i];
            }
            Console.WriteLine(reverseWord);
        }
    }
}
