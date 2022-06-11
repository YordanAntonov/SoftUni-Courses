using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreaterOfTwoValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string variable = Console.ReadLine();
            switch (variable)
            {
                case "int":
                    int firstInt = int.Parse(Console.ReadLine());
                    int secondInt = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstInt, secondInt));
                    break;
                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(firstChar, secondChar));
                    break;
                case "string":
                    string firstString = Console.ReadLine();
                    string secondString = Console.ReadLine();
                    Console.WriteLine(GetMax(firstString, secondString));   
                    break;
            }
        }
        static int GetMax(int firstInt, int secondInt)
        {
            if (firstInt > secondInt)
            {
                return firstInt;
            }

            return secondInt;
        }

        static char GetMax(char firstChar, char secondChar)
        {
            if (secondChar < firstChar)
            {
                return firstChar;
            }

            return secondChar;
        }

        static string GetMax(string firstString, string secondString)
        {
            int result = firstString.CompareTo(secondString);
            if (result > 0)
            {
                return firstString;
            }

            return secondString;
        }
    }
}
