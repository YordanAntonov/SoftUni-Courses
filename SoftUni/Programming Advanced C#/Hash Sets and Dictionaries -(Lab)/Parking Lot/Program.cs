using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();

            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] tokens = command.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string licensePlate = tokens[1];

                if (action == "IN")
                {
                    carNumbers.Add(licensePlate);
                }
                else if (action == "OUT")
                {
                    carNumbers.Remove(licensePlate);
                }

                command = Console.ReadLine();
            }

            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in carNumbers)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
