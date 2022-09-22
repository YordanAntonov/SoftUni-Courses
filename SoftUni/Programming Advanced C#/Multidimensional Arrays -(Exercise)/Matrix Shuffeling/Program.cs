using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_Shuffeling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(x => int.Parse(x)).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols];


            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] rowInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string tempRow = "";
                //string tempCol = "";

                if (CheckValidation(tokens, matrix))
                {
                    int row1 = int.Parse(tokens[1]);
                    int col1 = int.Parse(tokens[2]);
                    int row2 = int.Parse(tokens[3]);
                    int col2 = int.Parse(tokens[4]);

                    tempRow = matrix[row1, col1];
                    //tempCol = row2;
                    matrix[row1, col1] = matrix[row2, col2];
                    matrix[row2, col2] = tempRow;
                    printMatrix(matrix);
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }

        }

        static void printMatrix(string[,] matrix)
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

        private static bool CheckValidation(string[] tokens, string[,] matrix)
        {
            return tokens[0] == "swap" && tokens.Length == 5 && int.Parse(tokens[1]) >= 0 && int.Parse(tokens[1]) < matrix.GetLength(0)
                && int.Parse(tokens[2]) >= 0 && int.Parse(tokens[2]) < matrix.GetLength(1) && int.Parse(tokens[3]) >= 0 && int.Parse(tokens[3]) < matrix.GetLength(0) && int.Parse(tokens[4]) >= 0 && int.Parse(tokens[4]) < matrix.GetLength(1);
        }
    }
}
