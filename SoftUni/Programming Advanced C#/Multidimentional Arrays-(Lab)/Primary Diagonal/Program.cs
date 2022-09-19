using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimensions = int.Parse(Console.ReadLine());
            int rows = dimensions;
            int cols = dimensions;
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] matrixInfo = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = matrixInfo[col];
                }
            }
            int sum = 0;

            for (int row = 0; row < rows; row++)
            {
                
                for (int col = 0; col < cols; col++)
                {
                    if (row == col)
                    {
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine(sum);

            
        }
    }
}
