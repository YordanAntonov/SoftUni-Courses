using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numPersons = int.Parse(Console.ReadLine());
            int maxPersons = int.Parse(Console.ReadLine());

            double rounds = Math.Ceiling((double)numPersons / maxPersons);
            Console.WriteLine(rounds);
        }
    }
}
