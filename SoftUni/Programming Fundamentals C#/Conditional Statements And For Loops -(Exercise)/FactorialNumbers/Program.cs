using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string numberLenght = number.ToString();
            int inputNumber = number;

            int factorialNumSum = 0;

            for (int i = 0; i < numberLenght.Length; i++) // big loop rotating the length of the number!
            {
                int lastDigit = inputNumber % 10; // to take the last digit of the number!
                int currentDigitFactorel = lastDigit;

                if(currentDigitFactorel == 0)
                {
                    factorialNumSum++;
                    inputNumber /= 10;
                    continue;
                }

                for (int j = lastDigit -1; j >= 1; j--) // Looping the current digit of the number from highest to lowest to check the factorials!
                {
                    currentDigitFactorel *= j;                  
                }
                factorialNumSum += currentDigitFactorel;
                inputNumber /= 10;


            }
            if (factorialNumSum == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}
