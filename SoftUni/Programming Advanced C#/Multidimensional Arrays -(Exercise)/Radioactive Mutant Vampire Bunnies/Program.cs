using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radioactive_Mutant_Vampire_Bunnies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];
            char[,] matrix = new char[rows, cols];

            int playerRow = 0;
            int playerCol = 0;

            for (int row = 0; row < rows; row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInput[col];
                    if (matrix[row, col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            string commands = Console.ReadLine();

            foreach (var cmd in commands)
            {
                bool playerWon = false;
                bool playerLost = false;

                int newPLayerRow = playerRow;
                int newPlayerCol = playerCol;

                switch (cmd)
                {
                    case 'U':
                        matrix[playerRow, playerCol] = '.';
                        newPLayerRow--;
                        MovePlayer(newPLayerRow, playerCol, ref playerWon, ref playerLost, matrix);
                        break;

                    case 'D':
                        matrix[playerRow, playerCol] = '.';
                        newPLayerRow++;
                        MovePlayer(newPLayerRow, playerCol, ref playerWon, ref playerLost, matrix);
                        break;

                    case 'L':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerCol--;
                        MovePlayer(playerRow, newPlayerCol, ref playerWon, ref playerLost, matrix);
                        break;

                    case 'R':
                        matrix[playerRow, playerCol] = '.';
                        newPlayerCol++;
                        MovePlayer(playerRow, newPlayerCol, ref playerWon, ref playerLost, matrix);
                        break;
                }

                matrix = BunnyMultiplication(matrix, ref playerLost);

                if (playerWon)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }

                playerRow = newPLayerRow;
                playerCol = newPlayerCol;

                if (playerLost)
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] BunnyMultiplication(char[,] matrix, ref bool playerLost)
        {
            char[,] newMatrix = CopyMatrix(matrix);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (IsCellValid(row - 1, col, matrix))//Up
                        {
                            if (matrix[row - 1, col] == 'P')
                            {
                                playerLost = true;
                            }
                            newMatrix[row - 1, col] = 'B';
                        }
                        if (IsCellValid(row + 1, col, matrix))//Down
                        {
                            if (matrix[row + 1, col] == 'P')
                            {
                                playerLost = true;
                            }
                            newMatrix[row + 1, col] = 'B';
                        }
                        if (IsCellValid(row, col - 1, matrix))//Left
                        {
                            if (matrix[row, col - 1] == 'P')
                            {
                                playerLost = true;
                            }
                            newMatrix[row, col - 1] = 'B';
                        }
                        if (IsCellValid(row, col + 1, matrix))//Right
                        {
                            if (matrix[row, col + 1] == 'P')
                            {
                                playerLost = true;
                            }
                            newMatrix[row, col + 1] = 'B';
                        }
                    }
                }
            }
            return newMatrix;
        }

        private static void MovePlayer(int playerRow, int playerCol, ref bool playerWon, ref bool playerLost, char[,] matrix)
        {
            if (IsCellValid(playerRow, playerCol, matrix))
            {
                if (matrix[playerRow, playerCol] == 'B')
                {
                    playerLost = true;
                }
                else
                {
                    matrix[playerRow, playerCol] = 'P';
                }
            }
            else
            {
                playerWon = true;
            }
        }

        private static bool IsCellValid(int row, int col, char[,] matrix)
        {
            return row >= 0 && row < matrix.GetLength(0)
                && col >= 0 && col < matrix.GetLength(1);
        }

        private static char[,] CopyMatrix(char[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            char[,] copyMatrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    copyMatrix[row, col] = matrix[row, col];
                }
            }
            return copyMatrix;
        }
    }
}
