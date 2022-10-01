using System;
using System.Linq;

namespace Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> minNumberFunc = numbers =>
            {
                int minValue = int.MaxValue;

                foreach (var num in numbers)
                {
                    if (num < minValue)
                    {
                        minValue = num;
                    }
                }
                return minValue;
            };

            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int minValue = minNumberFunc(numbers);
            Console.WriteLine(minValue);    
        }
    }
}
