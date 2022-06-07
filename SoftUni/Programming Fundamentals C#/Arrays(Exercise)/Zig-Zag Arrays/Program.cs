using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zig_Zag_Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            int[] evenNums = new int [lines];
            int[] oddNums = new int [lines];
            for (int i = 0; i < lines; i++)
            {
                int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (i % 2 == 0)
                {
                    evenNums[i] = inputArray[0];
                    oddNums[i] = inputArray[1];
                }
                else
                {
                    evenNums[i] = inputArray[1];
                    oddNums[i] = inputArray[0];
                }
            }
            foreach (int even in evenNums)
            {
                Console.Write($"{even} ");
            }
            Console.WriteLine();
            foreach (int odd in oddNums)
            {
                Console.Write($"{odd} ");
            }
        }
    }
}
