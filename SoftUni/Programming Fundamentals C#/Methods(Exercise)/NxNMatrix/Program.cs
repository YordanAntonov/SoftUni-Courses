using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NxNMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            PrintNxN(number);

        }

        static void PrintNxN(int number)
        {
            for (int column = 1; column <= number; column++)
            {
                for (int row = 1; row <= number; row++)
                {
                    Console.Write($"{number} ");
                }
                Console.WriteLine();
            }
        }
    }
}
