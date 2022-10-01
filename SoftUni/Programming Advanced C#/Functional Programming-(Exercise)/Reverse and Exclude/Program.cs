using System;
using System.Collections.Generic;
using System.Linq;

namespace Reverse_and_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> reverser = numbers =>
            {
                List<int> reversed = new List<int>();
                for (int i = numbers.Count - 1; i >= 0; i--)
                {
                    reversed.Add(numbers[i]);
                }
                return reversed;
            };
            Func<List<int>, Predicate<int>, List<int>> numRemover = (numbers, match) =>
            {
                List<int> newNumbers = new List<int>();
                foreach (var num in numbers)
                {
                    if (!match(num))
                    {
                        newNumbers.Add(num);
                    }
                }
                return newNumbers;
            };

            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int divisor = int.Parse(Console.ReadLine());

            numbers = numRemover(numbers, x => x % divisor == 0);
            numbers = reverser(numbers);

            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}
