using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> customers = new Queue<string>();
            while (true)
            {
                if (input == "End")
                {
                    break;
                }
                if (input == "Paid")
                {
                    while (customers.Count > 0)
                    {
                        Console.WriteLine(customers.Dequeue());
                    }
                }
                else
                {
                    customers.Enqueue(input);
                }

                input = Console.ReadLine();
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
