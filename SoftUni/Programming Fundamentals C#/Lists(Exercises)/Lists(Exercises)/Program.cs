using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists_Exercises_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine().Split().Select(int.Parse).ToList();
            int maxCapacityPerWagon = int.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            while (command != "end")
            {
                FindTheWagon(wagons, maxCapacityPerWagon, command);
                command = Console.ReadLine();
            }
                Console.WriteLine(String.Join(" ", wagons));
        }
        static void FindTheWagon(List<int> wagons, int maxCapacity, string command)
        {
            string[] tokens = command.Split(' ');
            if (tokens.Length > 1) // Command == Add number
            {
                int addedPassangers = int.Parse(tokens[1]);
                wagons.Add(addedPassangers);
            }
            else if (tokens.Length < 2)
            {
                int addedPassangers = int.Parse(tokens[0]);

                for (int i = 0; i < wagons.Count; i++)
                {
                    int currWagon = wagons[i];
                    if (addedPassangers + currWagon <= maxCapacity)
                    {
                        wagons[i] += addedPassangers;
                        break;
                    }
                }
            }
        }
    }
}
