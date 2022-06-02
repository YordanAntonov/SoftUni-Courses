using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseArrayOfStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split(' ').Reverse().ToArray();
            foreach ( string word in words)
            {
                
                Console.Write($"{word} ");
            }
        }
    }
}
