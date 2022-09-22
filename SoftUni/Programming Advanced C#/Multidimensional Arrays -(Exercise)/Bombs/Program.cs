using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dimentions = int.Parse(Console.ReadLine());
            int rows = dimentions;
            int cols = dimentions;
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowNums = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowNums[col];
                }
            }
            string[] indexPairs = Console.ReadLine().Split();

            foreach (var pair in indexPairs)
            {
                int[] indexes = pair.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int row = indexes[0];
                int col = indexes[1];
                Exploding(matrix, row, col);
            }

            int aliveCells = 0;
            int sum = 0;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        sum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sum}");
            PrintMatrix(matrix);



        }

        private static void Exploding(int[,] matrix, int row, int col)
        {
            int value = matrix[row, col];

            if (value > 0)
            {
                matrix[row, col] = 0;

                if (row > 0 && matrix[row - 1, col] > 0)//Top
                {
                    matrix[row - 1, col] -= value;
                }
                if (row < matrix.GetLength(0) - 1 && matrix[row + 1, col] > 0)//Bottom
                {
                    matrix[row + 1, col] -= value;
                }
                if (col > 0 && matrix[row, col - 1] > 0)//Left
                {
                    matrix[row, col - 1] -= value;
                }
                if (col < matrix.GetLength(1) - 1 && matrix[row, col + 1] > 0)//Right
                {
                    matrix[row, col + 1] -= value;
                }
                if (col > 0 && row > 0 && matrix[row - 1, col - 1] > 0)//Top Left
                {
                    matrix[row - 1, col - 1] -= value;
                }
                if (col < matrix.GetLength(1) - 1 && row > 0 && matrix[row - 1, col + 1] > 0)//Top Right
                {
                    matrix[row - 1, col + 1] -= value;
                }
                if (row < matrix.GetLength(0) - 1 && col > 0 && matrix[row + 1, col - 1] > 0)//Bot Left
                {
                    matrix[row + 1, col - 1] -= value;
                }
                if (row < matrix.GetLength(0) - 1 && col < matrix.GetLength(1) - 1 && matrix[row + 1, col + 1] > 0)// Bot Right
                {
                    matrix[row + 1, col + 1] -= value;
                }

            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {

                    Console.Write($"{matrix[row, col]} ");

                }
                Console.WriteLine();
            }
        }

    }
}
