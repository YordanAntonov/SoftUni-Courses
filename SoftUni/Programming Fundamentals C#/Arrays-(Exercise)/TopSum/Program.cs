using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftSum = 0;
            int rightSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {

                if (numbers.Length == 1)
                {
                    Console.WriteLine(0);
                    return;
                }

                leftSum = 0;
                // For loop for the left sum which is going to be reversed!
                for (int leftCount = i; leftCount > 0; leftCount--)
                {
                    int nextLeftNumber = leftCount - 1;
                    if (leftCount > 0)
                    {
                        leftSum += numbers[nextLeftNumber];
                    }
                }

                rightSum = 0;
                //For loop for the right sum which will go from the current index towards the end of the array!
                for (int rightCount = i; rightCount < numbers.Length; rightCount++)
                {
                    int nextRightNumber = rightCount + 1;
                    if (rightCount < numbers.Length - 1)
                    {
                        rightSum += numbers[nextRightNumber];
                    }
                }

                if (leftSum == rightSum)
                {
                    Console.WriteLine(i);
                    return;
                }
            }
            Console.WriteLine("no");
        }
    }
}
