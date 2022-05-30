using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int mainYield = int.Parse(Console.ReadLine());
            const int workersFood = 26;
            int days = 0;
            int totalHarvest = 0;

            while (mainYield >= 100)
            {
                int harvest = mainYield;
                days++;
                harvest -= workersFood;
                              

                totalHarvest += harvest;
                mainYield -= 10;

            }
            if (totalHarvest >= workersFood)
            {
            totalHarvest -= workersFood;
            }
            Console.WriteLine(days);
            Console.WriteLine(totalHarvest);
        }
    }
}
