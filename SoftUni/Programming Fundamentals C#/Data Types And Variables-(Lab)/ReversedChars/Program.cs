using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReversedChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char chOne = char.Parse(Console.ReadLine());
            char chTwo = char.Parse(Console.ReadLine());
            char chThree = char.Parse(Console.ReadLine());

            Console.WriteLine($"{chThree} {chTwo} {chOne}");
        }
    }
}
