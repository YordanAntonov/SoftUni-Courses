using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] jagged = new double[rows][];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                double[] integers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jagged[row] = integers;
            }

            for (int row = 0; row < jagged.GetLength(0) - 1; row++)
            {
                if (jagged[row].Length == jagged[row + 1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;
                    }
                    for (int col = 0; col < jagged[row + 1].Length; col++)
                    {
                        jagged[row + 1][col] /= 2;
                    }

                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                int row = int.Parse(tokens[1]);
                int column = int.Parse(tokens[2]);
                double value = int.Parse(tokens[3]);

                if (ValidateIndex(jagged, row, column))
                {
                    switch (action)
                    {
                        case "Add":
                            jagged[row][column] += value;
                            break;
                        case "Subtract":
                            jagged[row][column] -= value;
                            break;
                    }
                }

                command = Console.ReadLine();
            }

            PrintMatrix(jagged);
        }
        static bool ValidateIndex(double[][] jagged, int row, int column)
        {
            return row >= 0 && row < jagged.GetLength(0) && column >= 0 && column < jagged[row].Length;
        }

        static void PrintMatrix(double[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write($"{jagged[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
