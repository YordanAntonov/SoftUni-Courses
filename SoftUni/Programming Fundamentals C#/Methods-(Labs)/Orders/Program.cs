using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());
            CalculatePrice(product, quantity);
        }

        static void CalculatePrice(string product, int quantity)
        {
            double result = 0;
            switch (product)
            {
                case "coffee":
                    result = quantity * 1.50;
                    Console.WriteLine($"{result:f2}");
                    break;
                case "water":
                    result = quantity * 1.00;
                    Console.WriteLine($"{result:f2}");
                    break;
                case "coke":
                    result = quantity * 1.40;
                    Console.WriteLine($"{result:f2}");
                    break;
                case "snacks":
                    result = quantity * 2.00;
                    Console.WriteLine($"{result:f2}");
                    break;
            }

        }
    }

}
