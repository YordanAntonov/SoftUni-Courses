using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            CheckForTopNum(number);

        }

        static void CheckForTopNum(int number)
        {
            for (int i = 1; i <= number; i++)
            {
                int sumOfDigits = 0;
                int oddNumCount = 0;
                int currCheckingNum = i;
                while (currCheckingNum != 0)
                {
                    int currentDigit = currCheckingNum % 10;
                    currCheckingNum /= 10;
                    sumOfDigits += currentDigit;
                    if (currentDigit % 2 != 0)
                    {
                        oddNumCount++;
                    }
                }
                if (sumOfDigits % 8 == 0 && oddNumCount > 0)
                {
                    Console.WriteLine(i);
                }

            }

        }
    }
}
