using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knight_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int boardDimensions = int.Parse(Console.ReadLine());
            int rows = boardDimensions;
            int cols = boardDimensions;
            char[,] board = new char[rows, cols];

            if (boardDimensions < 3)
            {
                Console.WriteLine(0);

                return;
            }

            for (int row = 0; row < rows; row++)
            {
                string rowInput = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    board[row, col] = rowInput[col];
                }
            }
            // K == Knight
            // 0 == Empty place
            int removedKnights = 0;

            while (true)
            {

                int currKnightRow = 0;
                int currKnightCol = 0;
                int maxNumAtackedKnights = 0;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (board[row, col] == 'K')
                        {
                            int atackedKnights = CheckForAtackedKnights(row, col, board);

                            if (maxNumAtackedKnights < atackedKnights)
                            {
                                maxNumAtackedKnights = atackedKnights;
                                currKnightRow = row;
                                currKnightCol = col;
                            }
                        }
                    }
                }
                if (maxNumAtackedKnights == 0)
                {
                    break;
                }
                else
                {
                    board[currKnightRow, currKnightCol] = '0';
                    removedKnights++;
                }

            }

            Console.WriteLine(removedKnights);

        }

        private static int CheckForAtackedKnights(int row, int col, char[,] board)
        {
            int atackedKnights = 0;
            if (ValidateCell(row - 2, col - 1, board)) //Up-Left (1)
            {
                if (board[row - 2, col - 1] == 'K')
                {
                    atackedKnights++;
                }
            }

            if (ValidateCell(row - 2, col + 1, board)) //Up-Right (2)
            {
                if (board[row - 2, col + 1] == 'K')
                {
                    atackedKnights++;
                }
            }

            if (ValidateCell(row - 1, col + 2, board)) //Right-Up (3)
            {
                if (board[row - 1, col + 2] == 'K')
                {
                    atackedKnights++;
                }
            }

            if (ValidateCell(row + 1, col + 2, board)) //Right-Down (4)
            {
                if (board[row + 1, col + 2] == 'K')
                {
                    atackedKnights++;
                }
            }

            if (ValidateCell(row + 2, col + 1, board)) //Down-Right (5)
            {
                if (board[row + 2, col + 1] == 'K')
                {
                    atackedKnights++;
                }
            }

            if (ValidateCell(row + 2, col - 1, board)) //Down-Left (6)
            {
                if (board[row + 2, col - 1] == 'K')
                {
                    atackedKnights++;
                }
            }

            if (ValidateCell(row - 1, col - 2, board)) //Left-Up (7)
            {
                if (board[row - 1, col - 2] == 'K')
                {
                    atackedKnights++;
                }
            }

            if (ValidateCell(row + 1, col - 2, board)) //Left-Down (8)
            {
                if (board[row + 1, col - 2] == 'K')
                {
                    atackedKnights++;
                }
            }

            return atackedKnights;
        }

        static bool ValidateCell(int row, int col, char[,] board)
        {
            return row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
        }
    }
}
