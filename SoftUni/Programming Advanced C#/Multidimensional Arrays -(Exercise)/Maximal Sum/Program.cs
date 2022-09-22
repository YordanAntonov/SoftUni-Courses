using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maximal_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            int[,] matrix = new int[rows, cols];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rowNums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowNums[col];
                }
            }

            int currRow = 0;
            int currCol = 0;
            int squareTotalSum = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {

                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currSquareSum = 0;

                    currSquareSum += matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                        + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                        + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currSquareSum > squareTotalSum)
                    {
                        currRow = row;
                        currCol = col;
                        squareTotalSum = currSquareSum;
                    }
                }

            }

            Console.WriteLine($"Sum = {squareTotalSum}");
            for (int row = currRow; row < currRow + 3; row++)
            {
                for (int col = currCol; col < currCol + 3; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
