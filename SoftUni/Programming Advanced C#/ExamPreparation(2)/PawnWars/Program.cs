using System;

namespace PawnWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int size = 8;

            char[,] chessBoard = new char[size, size];

            int whiteRow = 0;
            int whiteCol = 0;
            //***************
            int blackRow = 0;
            int blackCol = 0;

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                string rowInput = Console.ReadLine();

                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = rowInput[col];

                    if (chessBoard[row, col] == 'w')
                    {
                        whiteRow = row;
                        whiteCol = col;
                    }

                    if (chessBoard[row, col] == 'b')
                    {
                        blackRow = row;
                        blackCol = col;
                    }
                }
            }

            bool isWhiteTurn = true;

            while (true)
            {
                if (isWhiteTurn)
                {
                    if (whiteRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {(char)(whiteCol + 97)}8.");
                        return;
                    }

                    if (IsValid(whiteRow - 1, whiteCol - 1, chessBoard) && chessBoard[whiteRow - 1, whiteCol - 1] == 'b')//Up-Left Diagonal
                    {

                            whiteRow--;
                            whiteCol--;

                            Console.WriteLine($"Game over! White capture on {(char)(97 + whiteCol)}{8 - whiteRow}.");
                            return;
                        
                    }
                    else if (IsValid(whiteRow - 1, whiteCol + 1, chessBoard) && chessBoard[whiteRow - 1, whiteCol + 1] == 'b')//Up-Right Diagonal
                    {                      
                            whiteRow--;
                            whiteCol++;

                            Console.WriteLine($"Game over! White capture on {(char)(97 + whiteCol)}{8 - whiteRow}.");
                            return;                        
                    }

                    whiteRow--;
                    chessBoard[whiteRow, whiteCol] = 'w';
                }
                else
                {
                    if (blackRow == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {(char)(blackCol + 97)}{1}.");
                        return;
                    }

                    if (IsValid(blackRow + 1, blackCol - 1, chessBoard) && chessBoard[blackRow + 1, blackCol - 1] == 'w')//Down-Left Diagonal
                    {                    
                            blackRow++;
                            blackCol--;

                            Console.WriteLine($"Game over! Black capture on {(char)(97 + blackCol)}{8 - blackRow}.");
                            return;                       
                    }
                    else if (IsValid(blackRow + 1, blackCol + 1, chessBoard) && chessBoard[blackRow + 1, blackCol + 1] == 'w')//Down-Right Diagonal
                    {                                              
                            blackRow++;
                            blackCol++;

                            Console.WriteLine($"Game over! Black capture on {(char)(97 + blackCol)}{8 - blackRow}.");
                            return;                      
                    }

                    blackRow++;
                    chessBoard[blackRow, blackCol] = 'b';
                }

                isWhiteTurn = !isWhiteTurn;
            }
        }
        static bool IsValid(int row, int col, char[,] board) => row >= 0 && row < board.GetLength(0) && col >= 0 && col < board.GetLength(1);
    }
}
