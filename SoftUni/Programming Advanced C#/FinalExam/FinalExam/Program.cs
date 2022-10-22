using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> coffeineMiligrams = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            const int maxMiligramsPerDay = 300;

            int initialCoffeineMg = 0;

            while (coffeineMiligrams.Count > 0 && energyDrinks.Count > 0)
            {
                int currMiligrams = coffeineMiligrams.Pop();
                int currEnergyDrink = energyDrinks.Dequeue();

                int sumOfMiligrams = currMiligrams * currEnergyDrink;
                int thresholdChecker = sumOfMiligrams + initialCoffeineMg;

                if (thresholdChecker <= maxMiligramsPerDay)
                {
                    initialCoffeineMg += sumOfMiligrams;
                }
                else
                {
                    if (initialCoffeineMg >= 30)
                    {
                        initialCoffeineMg -= 30;
                    }

                    energyDrinks.Enqueue(currEnergyDrink);
                }
            }

            if (energyDrinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
            }
            else
            {
                Console.WriteLine($"At least Stamat wasn't exceeding the maximum caffeine.");
            }

            Console.WriteLine($"Stamat is going to sleep with {initialCoffeineMg} mg caffeine.");
        }
    }
}
