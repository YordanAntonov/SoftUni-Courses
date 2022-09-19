using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rowCols = int.Parse(Console.ReadLine());
            int rows = rowCols;
            int cols = rowCols;

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string chars = Console.ReadLine();
                char[] rowInfo = chars.ToCharArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInfo[col];
                }
            }

            char findChar = char.Parse(Console.ReadLine());
            bool charFound = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == findChar)
                    {
                        Console.WriteLine($"({row}, {col})");
                        charFound = true;
                        break;
                    }
                }
                if (charFound) break;
            }

            if (!charFound)
            {
                Console.WriteLine($"{findChar} does not occur in the matrix");
            }
        }
    }
}
