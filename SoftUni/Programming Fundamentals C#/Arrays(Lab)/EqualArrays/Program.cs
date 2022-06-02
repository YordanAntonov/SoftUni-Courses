using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EqualArrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] secondArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int sum = 0;
            bool notEqual = false;
            int breakInd = 0;
            for (int i = 0; i < firstArray.Length; i++)
            {
                if (firstArray[i] != secondArray[i])
                {
                    notEqual = true;
                    breakInd = i;
                    break;
                }
                else
                {
                    sum += firstArray[i];
                }
            }
            if (notEqual)
            {
                Console.WriteLine($"Arrays are not identical. Found difference at {breakInd} index");
            }
            else
            {
                Console.WriteLine($"Arrays are identical. Sum: {sum}");
            }
        }
    }
}
