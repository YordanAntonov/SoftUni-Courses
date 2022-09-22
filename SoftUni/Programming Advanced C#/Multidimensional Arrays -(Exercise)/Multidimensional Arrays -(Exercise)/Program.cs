using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multidimensional_Arrays___Exercise_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            int rows = dimensions;
            int cols = dimensions;
            int[,] matrix = new int[rows, cols];
            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] rowNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowNums[col];
                }
            }

            for (int row = 0, i = matrix.GetLength(0) - 1; row < rows; row++, i--)
            {
                primaryDiagonalSum += matrix[row, row];
                secondaryDiagonalSum += matrix[row, i];
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondaryDiagonalSum));
        }
    }
}
