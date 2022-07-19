using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Char_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Console.WriteLine(GetStringSum(input[0], input[1]));

        }

        private static int GetStringSum(string stringOne, string stringTwo)
        {
            int sum = 0;

            string shortestString = "";
            string longestString = "";

            if (stringOne.Length > stringTwo.Length)
            {
                longestString = stringOne;
                shortestString = stringTwo;
            }
            else 
            {
                longestString = stringTwo;
                shortestString = stringOne;
            }

            for (int i = 0; i < shortestString.Length; i++)
            {
                sum += stringOne[i] * stringTwo[i];
            }

            for (int i = shortestString.Length; i < longestString.Length; i++)
            {
                sum += longestString[i];
            }

            return sum;
        }
    }
}
