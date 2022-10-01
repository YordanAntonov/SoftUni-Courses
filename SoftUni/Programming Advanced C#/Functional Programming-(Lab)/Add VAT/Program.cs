using System;
using System.Linq;

namespace Add_VAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> addVat = n => n * 1.20;

            double[] prices = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).Select(addVat).ToArray();

            foreach (var price in prices)
            {
                Console.WriteLine($"{price:f2}");
            }
        }
    }
}
