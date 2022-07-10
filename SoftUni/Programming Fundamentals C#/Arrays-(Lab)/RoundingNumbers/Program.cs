using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (double num in numbers)
            {
               double roundNum = Math.Round(num, MidpointRounding.AwayFromZero);
               Console.WriteLine($"{num} => {(int)roundNum}");
            }
        }
    }
}
