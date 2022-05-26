using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoundsToDollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double paunds = double.Parse(Console.ReadLine());

            double dollars = 1.31 * paunds;
            Console.WriteLine($"{dollars:f3}");
        }
    }
}
