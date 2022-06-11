using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyEvensbyOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startNum = int.Parse(Console.ReadLine());
            int enterNum = Math.Abs(startNum);
            int result = GetSumOfEvenAndOdds(CalcEvenSum(enterNum), CalcOddSum(enterNum));
            Console.WriteLine(result);
        }

        static int CalcEvenSum(int enterNum)
        {
            int evenSum = 0;
            while (enterNum > 0)
            {
                int currentDigit = enterNum % 10;
                if(currentDigit % 2 == 0)
                {
                    evenSum += currentDigit;
                }
                enterNum /= 10;
            }
            return evenSum;
        }static int CalcOddSum(int enterNum)
        {
            int oddSum = 0;
            while (enterNum > 0)
            {
                int currentDigit = enterNum % 10;
                if(currentDigit % 2 != 0)
                {
                    oddSum += currentDigit;
                }
                enterNum /= 10;
            }
            return oddSum;
        }
        static int GetSumOfEvenAndOdds(int evenSum, int oddSum)
        {
            int result = Math.Abs(evenSum * oddSum);
            return result;
        }


    }
}
