using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            char[,] matrix = new char[rows, cols];

            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowChars = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowChars[col];
                }
            }

            int squaresFound = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    char currChar = matrix[row, col];
                    if (currChar == matrix[row, col + 1] && currChar == matrix[row + 1, col + 1] && currChar == matrix[row + 1, col])
                    {
                        squaresFound++;
                    }
                }
            }

            Console.WriteLine(squaresFound);
        }
    }
}
