using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDataTypesAndVariables
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Meters to Kilometers
            int meters = int.Parse(Console.ReadLine());
            double kilometers = meters / 1000.0;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}
