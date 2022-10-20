using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Lake lake = new Lake(numbers);

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
