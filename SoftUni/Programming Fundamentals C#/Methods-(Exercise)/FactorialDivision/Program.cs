using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialDivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num1Factorials = GetFactorials(num1);
            int num2Factorials = GetFactorials(num2);
            double result = GetFactorialDivision(num1Factorials, num2Factorials);
            PrintResult(result);
        }

        static int GetFactorials(int num)
        {
            int factorials = 1;

            for (int i = 1; i <= num; i++)
            {
                factorials *= i;
            }
            return factorials;
        }

        static double GetFactorialDivision(int num1, int num2)
        {
            double result = (double)num1 / num2;
            return result;
        }
        static void PrintResult(double result) => Console.WriteLine($"{result:f2}");

    }
}
