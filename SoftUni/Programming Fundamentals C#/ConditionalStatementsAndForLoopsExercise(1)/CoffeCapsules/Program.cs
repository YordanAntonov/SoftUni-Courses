using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeCapsules
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double totalSum = 0;

            for (int i = 1; i <= number; i++)
            {
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse(Console.ReadLine());
                int capsulesCaunt = int.Parse(Console.ReadLine());
                double finalPrice = ((days * capsulesCaunt) * pricePerCapsule);
                totalSum += finalPrice;
                Console.WriteLine($"The price for the coffee is: ${finalPrice:f2}");

            }
            Console.WriteLine($"Total: ${totalSum:f2}");

        }
    }
}
