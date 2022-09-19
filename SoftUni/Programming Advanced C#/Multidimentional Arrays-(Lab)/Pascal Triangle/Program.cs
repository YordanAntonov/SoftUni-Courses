using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal_Triangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            long[][] pascal = new long[n][];

            for (int row = 0; row < n; row++)
            {
                pascal[row] = new long[row + 1];

                for (int col = 0; col < pascal[row].Length; col++)
                {
                    long currValue = 0;
                    if (row == 0)
                    {
                        pascal[row][col] = 1;
                        continue;
                    }
                    if (col > 0 && row > 0) // Checks if there is element Upper-Left
                    {
                        currValue += pascal[row - 1][col - 1];
                    }

                    if (pascal[row].Length - 1 > col) // Checks for element Above
                    {
                        currValue += pascal[row - 1][col];
                    }

                    pascal[row][col] = currValue;
                }
            }

            for (int row = 0; row < pascal.Length; row++)
            {
                for (int col = 0; col < pascal[row].Length; col++)
                {
                    Console.Write($"{pascal[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
