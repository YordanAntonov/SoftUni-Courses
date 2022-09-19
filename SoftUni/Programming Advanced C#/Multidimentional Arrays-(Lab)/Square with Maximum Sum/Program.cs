using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Square_with_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            int[,] matrix = new int[rows, cols];
            int subRows = 2;
            int subCols = 2;


            for (int row = 0; row < rows; row++)
            {
                int[] rowInfo = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }

            int curSqrRow = 0;
            int curSqrCol = 0;
            int biggestSubMatrix = 0;

            for (int row = 0; row < rows - subRows + 1; row++)
            {
                for (int col = 0; col < cols - subCols + 1; col++)
                {
                    int subMatrixSum = 0;

                    subMatrixSum += matrix[row, col];
                    subMatrixSum += matrix[row + 1, col];
                    subMatrixSum += matrix[row, col + 1];
                    subMatrixSum += matrix[row + 1, col + 1];

                    if (subMatrixSum > biggestSubMatrix)
                    {
                        curSqrRow = row;
                        curSqrCol = col;
                        biggestSubMatrix = subMatrixSum;
                    }
                }
            }

            Console.WriteLine($"{matrix[curSqrRow, curSqrCol]} {matrix[curSqrRow, curSqrCol + 1]}");
            Console.WriteLine($"{matrix[curSqrRow + 1, curSqrCol]} {matrix[curSqrRow + 1, curSqrCol + 1]}");
            Console.WriteLine($"{biggestSubMatrix}");
        }
    }
}
