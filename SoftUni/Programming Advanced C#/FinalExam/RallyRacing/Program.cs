using System;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace RallyRacing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //************************INPUT**************************
            int size = int.Parse(Console.ReadLine());
            string racingCarNumber = Console.ReadLine();
            int rows = size;
            int cols = size;

            int currRow = 0;
            int currCol = 0;

            int tunnelOneRow = 0;
            int tunnelOneCol = 0;

            int tunnelTwoRow = 0;
            int tunnelTwoCol = 0;

            int tunnelIndicator = 1;

            int coveredKilometers = 0;
            bool hasReachedFinish = false;

            char[,] matrix = new char[rows, cols];
            //********************************************************

            for (int row = 0; row < rows; row++)
            {
                char[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInput[col];

                    if (matrix[row, col] == 'T')
                    {
                        if (tunnelIndicator == 1)
                        {
                            tunnelOneRow = row;
                            tunnelOneCol = col;
                            tunnelIndicator++;
                        }
                        else
                        {
                            tunnelTwoRow = row;
                            tunnelTwoCol = col;
                        }
                    }
                }
            }

            string command = Console.ReadLine();
            // If next position is '.' coveredKilometers += 10;
            //If next position is 'F' coveredKilometers += 10;
            //If next position is 'T' coveredKilometers += 30; => change the 'T' to '.';
            //If we reache the Finish we change the 'F' to 'C';
            while (command != "End")
            {

                switch (command)
                {
                    case "left":

                        if (matrix[currRow, currCol - 1] == 'F')
                        {
                            coveredKilometers += 10;
                            currCol--;
                            matrix[currRow, currCol] = 'C';
                            hasReachedFinish = true;
                        }
                        else if (matrix[currRow, currCol - 1] == 'T')
                        {
                            currCol--;
                            matrix[currRow, currCol] = '.';
                            coveredKilometers += 30;
                            if (currRow == tunnelOneRow && currCol == tunnelOneCol)//Check which tunnel it is ;
                            {
                                currRow = tunnelTwoRow;
                                currCol = tunnelTwoCol;
                                matrix[currRow, currCol] = '.';

                            }
                            else
                            {
                                currRow = tunnelOneRow;
                                currCol = tunnelOneCol;
                                matrix[currRow, currCol] = '.';
                            }
                        }
                        else if (matrix[currRow, currCol - 1] == '.')
                        {
                            currCol--;
                            coveredKilometers += 10;
                        }
                        break;

                    case "right":

                        if (matrix[currRow, currCol + 1] == 'F')
                        {
                            coveredKilometers += 10;
                            currCol++;
                            matrix[currRow, currCol] = 'C';
                            hasReachedFinish = true;
                        }
                        else if (matrix[currRow, currCol + 1] == 'T')
                        {
                            currCol++;
                            matrix[currRow, currCol] = '.';
                            coveredKilometers += 30;
                            if (currRow == tunnelOneRow && currCol == tunnelOneCol)//Check which tunnel it is ;
                            {
                                currRow = tunnelTwoRow;
                                currCol = tunnelTwoCol;
                                matrix[currRow, currCol] = '.';

                            }
                            else
                            {
                                currRow = tunnelOneRow;
                                currCol = tunnelOneCol;
                                matrix[currRow, currCol] = '.';
                            }
                        }
                        else if (matrix[currRow, currCol + 1] == '.')
                        {
                            currCol++;
                            coveredKilometers += 10;
                        }
                        break;

                    case "up":
                        if (matrix[currRow - 1, currCol] == 'F')
                        {
                            coveredKilometers += 10;
                            currRow--;
                            matrix[currRow, currCol] = 'C';
                            hasReachedFinish = true;
                        }
                        else if (matrix[currRow - 1, currCol] == 'T')
                        {
                            currRow--;
                            matrix[currRow, currCol] = '.';
                            coveredKilometers += 30;
                            if (currRow == tunnelOneRow && currCol == tunnelOneCol)//Check which tunnel it is ;
                            {
                                currRow = tunnelTwoRow;
                                currCol = tunnelTwoCol;
                                matrix[currRow, currCol] = '.';

                            }
                            else
                            {
                                currRow = tunnelOneRow;
                                currCol = tunnelOneCol;
                                matrix[currRow, currCol] = '.';
                            }
                        }
                        else if (matrix[currRow - 1, currCol] == '.')
                        {
                            currRow--;
                            coveredKilometers += 10;
                        }
                        break;

                    case "down":
                        if (matrix[currRow + 1, currCol] == 'F')
                        {
                            coveredKilometers += 10;
                            currRow++;
                            matrix[currRow, currCol] = 'C';
                            hasReachedFinish = true;
                        }
                        else if (matrix[currRow + 1, currCol] == 'T')
                        {
                            currRow++;
                            matrix[currRow, currCol] = '.';
                            coveredKilometers += 30;
                            if (currRow == tunnelOneRow && currCol == tunnelOneCol)//Check which tunnel it is ;
                            {
                                currRow = tunnelTwoRow;
                                currCol = tunnelTwoCol;
                                matrix[currRow, currCol] = '.';

                            }
                            else
                            {
                                currRow = tunnelOneRow;
                                currCol = tunnelOneCol;
                                matrix[currRow, currCol] = '.';
                            }
                        }
                        else if (matrix[currRow + 1, currCol] == '.')
                        {
                            currRow++;
                            coveredKilometers += 10;
                        }
                        break;
                }

                if (hasReachedFinish)
                {
                    break;
                }

                command = Console.ReadLine();
            }

            if (hasReachedFinish)
            {
                Console.WriteLine($"Racing car {racingCarNumber} finished the stage!");
                Console.WriteLine($"Distance covered {coveredKilometers} km.");
            }
            else
            {
                matrix[currRow, currCol] = 'C';
                Console.WriteLine($"Racing car {racingCarNumber} DNF.");
                Console.WriteLine($"Distance covered {coveredKilometers} km.");
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
            


            // Dont forget to change the last position of the car to 'C'
        }
    }
}
