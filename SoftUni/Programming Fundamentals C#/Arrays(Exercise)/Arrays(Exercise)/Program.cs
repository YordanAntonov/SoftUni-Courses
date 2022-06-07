using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays_Exercise_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numWagons = int.Parse(Console.ReadLine());
            int[] peopleInWagon = new int[numWagons];
            int sum = 0;

            for (int i = 0; i < peopleInWagon.Length; i++)
            {
                peopleInWagon[i] = int.Parse(Console.ReadLine());
                sum += peopleInWagon[i];
            }
            foreach (int wagon in peopleInWagon)
            {
                Console.Write($"{wagon} ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
