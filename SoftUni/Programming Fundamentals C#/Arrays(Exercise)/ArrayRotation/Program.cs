using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayRotation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rotations = int.Parse(Console.ReadLine());

            for (int i = 0; i < rotations; i++)
            {
                int temporatyNumOne = numbers[0];
                for (int operations = 0; operations < numbers.Length - 1; operations++)
                {
                    numbers[operations] = numbers[operations + 1];
                }
                    numbers[numbers.Length - 1] = temporatyNumOne;
            }
                Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
