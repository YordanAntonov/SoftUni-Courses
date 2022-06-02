using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintNumbersInReverseOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = int.Parse(Console.ReadLine());
            int[] nums = new int[numbers];
            for (int i = 0; i < numbers; i++)
            {
                nums[i] = int.Parse(Console.ReadLine());
            }
            for (int i = numbers - 1; i >= 0; i--)
            {
                Console.Write($"{nums[i]} ");
            }

        }
    }
}
