using System;
using System.Collections.Generic;
using System.Linq;

namespace List_Of_Predicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int, List<int>> listFiller = (numbers, endRange) =>
            {

                for (int i = 1; i <= endRange; i++)
                {
                    numbers.Add(i);
                }
                return numbers;
            };

            List<Predicate<int>> predicates = new List<Predicate<int>>();
            List<int> numbers = new List<int>();

            int endRange = int.Parse(Console.ReadLine());
            HashSet<int> divisors = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

            numbers = listFiller(numbers, endRange);

            foreach (var divider in divisors)
            {
                predicates.Add(p => p % divider == 0);
            }

            foreach (var num in numbers)
            {

                bool isDivisible = true;

                foreach (var match in predicates)
                {
                    if (!match(num))
                    {
                        isDivisible = false; break;
                    }
                }

                if (isDivisible)
                {
                    Console.Write($"{num} ");
                }

            }



            
        }
    }
}
