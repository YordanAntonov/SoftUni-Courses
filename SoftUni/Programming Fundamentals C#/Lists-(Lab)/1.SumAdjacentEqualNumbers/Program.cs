using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.SumAdjacentEqualNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<double> numbers = Console.ReadLine().Split().Select(double.Parse).ToList();

            for (int index = 0; index < numbers.Count - 1; index++)
            {
                if (numbers[index] == numbers[index + 1])
                {
                    numbers[index] += numbers[index + 1];
                    numbers.RemoveAt(index + 1);
                    index = -1;
                }
            }
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
