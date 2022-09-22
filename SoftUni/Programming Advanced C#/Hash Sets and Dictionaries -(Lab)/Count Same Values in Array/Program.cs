using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<double, int> numberPair = new Dictionary<double, int>();
            double[] numbers = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();

            foreach (var number in numbers)
            {
                if (!numberPair.ContainsKey(number))
                {
                    numberPair[number] = 0;
                }

                numberPair[number]++;
            }

            foreach (var num in numberPair)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
