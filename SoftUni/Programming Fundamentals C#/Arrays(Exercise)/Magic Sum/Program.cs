using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int combinationNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                for (int currNumber = i; currNumber < numbers.Length - 1; currNumber++)
                {
                    int nextNum = numbers[currNumber + 1];
                    if (numbers[i] + nextNum == combinationNum)
                    {
                        Console.WriteLine($"{numbers[i]} {nextNum}");
                        break;
                    }

                }
            }
        }
    }
}
