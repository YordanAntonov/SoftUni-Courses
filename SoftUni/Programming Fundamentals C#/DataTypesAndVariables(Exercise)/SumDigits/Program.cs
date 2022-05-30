using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumDigits
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int sum = 0;

            while (number != 0)
            {
                int currDigit = number % 10;
                sum += currDigit;
                number /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
