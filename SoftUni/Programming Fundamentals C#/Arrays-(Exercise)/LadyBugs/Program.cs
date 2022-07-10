using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LadyBugs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] field = new int[fieldSize]; // [0 0 0 0 0 0]  
            int[] ladyBugsIndex = Console.ReadLine().Split().Select(int.Parse).ToArray(); // [3 5]

            foreach (int index in ladyBugsIndex) // to put index of ladybugs in the field[]!
            {
                if (index >= 0 && index < field.Length)//[0 0 0 1 0 1]
                {
                    field[index] = 1;
                }
            }
            string flyInput = "";

            while ((flyInput = Console.ReadLine()) != "end")
            {
                string[] flyCommands = flyInput.Split(); // [0 right 1]
                int bugPosition = int.Parse(flyCommands[0]); //[0]
                string bugDirection = flyCommands[1]; //[right]
                int bugNextSpot = int.Parse(flyCommands[2]); //[1]
                bool isFirst = true;
                while (bugPosition >= 0 && bugPosition < field.Length && field[bugPosition] != 0)
                {
                    if (isFirst)
                    {
                        field[bugPosition] = 0;
                        isFirst = false;
                    }

                    if (bugDirection == "left")
                    {
                        bugPosition -= bugNextSpot;
                        if (bugPosition >= 0 && bugPosition < fieldSize)
                        {
                            if (field[bugPosition] == 0)
                            {
                                field[bugPosition] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        bugPosition += bugNextSpot;
                        if (bugPosition >= 0 && bugPosition < fieldSize)
                        {
                            if (field[bugPosition] == 0)
                            {
                                field[bugPosition] = 1;
                                break;
                            }
                        }
                    }
                }
            }
            Console.WriteLine(String.Join(" ", field));
        }
    }
}
