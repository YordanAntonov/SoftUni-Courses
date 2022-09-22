using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LastTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int maxCoals = 0;
            int startRow = 0;
            int startCol = 0;

            char[,] matrix = new char[size, size];

            string[] commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] rowInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowInput[col];
                    if (rowInput[col] == 'c')
                    {
                        maxCoals++;
                    }
                    else if (rowInput[col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }
                }
            }
            bool coalEmpty = false;
            bool isEnd = false;

            foreach (var cmd in commands)
            {
                switch (cmd)
                {
                    case "up":
                        if (startRow > 0)
                        {
                            matrix[startRow, startCol] = '*';
                            startRow--;
                            isEnd = CheckCell(matrix, startRow, startCol, ref maxCoals);
                        }
                        break;
                    case "down":
                        if (startRow < matrix.GetLength(0) - 1)
                        {
                            matrix[startRow, startCol] = '*';
                            startRow++;
                            isEnd = CheckCell(matrix, startRow, startCol, ref maxCoals);

                        }
                        break;
                    case "left":
                        if (startCol > 0)
                        {
                            matrix[startRow, startCol] = '*';
                            startCol--;
                            isEnd = CheckCell(matrix, startRow, startCol, ref maxCoals);
                        }
                        break;
                    case "right":
                        if (startCol < matrix.GetLength(1) - 1)
                        {
                            matrix[startRow, startCol] = '*';
                            startCol++;
                            isEnd = CheckCell(matrix, startRow, startCol, ref maxCoals);
                        }
                        break;

                }
                if (isEnd)
                {
                    break;
                }
            }

            if (matrix[startRow, startCol] == 'e')
            {
                Console.WriteLine($"Game over! ({startRow}, {startCol})");
                return;
            }

            if (maxCoals == 0)
            {
                Console.WriteLine($"You collected all coals! ({startRow}, {startCol})");
                return;
            }


            Console.WriteLine($"{maxCoals} coals left. ({startRow}, {startCol})");


        }

        private static bool CheckCell(char[,] matrix, int startRow, int startCol, ref int maxCoals)
        {
            switch (matrix[startRow, startCol])
            {
                case 'e':
                    return true;
                case 'c':
                    maxCoals--;
                    if (maxCoals == 0)
                    {
                        return true;
                    }
                    return false;

                default:
                    return false;
            }
        }
    }
}
