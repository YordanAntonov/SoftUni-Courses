using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int reservour = 255;
            int maxReserv = reservour;

            int numLines = int.Parse(Console.ReadLine());
            int sumOfLiters = 0;

            for (int i = 1; i <= numLines; i++)
            {
                int pouringLiters = int.Parse(Console.ReadLine());
                if (pouringLiters <= maxReserv)
                {
                    maxReserv -= pouringLiters;
                    sumOfLiters += pouringLiters;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
            }
            Console.WriteLine($"{sumOfLiters}");


        }
    }
}
