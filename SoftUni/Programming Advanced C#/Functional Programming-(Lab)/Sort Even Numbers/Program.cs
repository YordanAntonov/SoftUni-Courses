using System;
using System.Linq;

namespace Sort_Even_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sortedNumbers = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Where(x => x % 2 == 0).OrderBy(n => n).ToArray();

            Console.WriteLine(string.Join(", ", sortedNumbers));
        }
    }
}
