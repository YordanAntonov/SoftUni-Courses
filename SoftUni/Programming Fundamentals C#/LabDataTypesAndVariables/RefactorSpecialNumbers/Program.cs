using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());


            for (int i = 1; i <= number; i++)
            {
             int sum = 0;
             int currentNum = i;

                while (currentNum != 0)
                {
                    int currentDigit = 0;

                    currentDigit = currentNum % 10;

                    currentNum /= 10;
                    sum += currentDigit;
                }

                if (sum == 5 || sum == 7 || sum == 11)
                {
                    Console.WriteLine($"{i} -> True");
                } 
                else
                {
                    Console.WriteLine($"{i} -> False");
                }

                
            }
        }
    }
}
