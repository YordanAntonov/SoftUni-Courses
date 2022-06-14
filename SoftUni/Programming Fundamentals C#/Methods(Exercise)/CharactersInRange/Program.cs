using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharactersInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            GetCharacters(firstChar, secondChar);
        }

        static void GetCharacters(char firstChar, char secondChar)
        {
            int smallerChar = Math.Min(firstChar, secondChar);
            int biggerChar = Math.Max(firstChar, secondChar);
            for (int i = smallerChar + 1; i < biggerChar; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
