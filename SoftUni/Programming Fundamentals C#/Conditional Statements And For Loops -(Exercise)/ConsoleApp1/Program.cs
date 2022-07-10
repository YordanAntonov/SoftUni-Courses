using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double countOfStudents = double.Parse(Console.ReadLine());
            double pricelightSabers = double.Parse(Console.ReadLine());
            double priceRobes = double.Parse(Console.ReadLine());
            double priceBelts = double.Parse(Console.ReadLine());
            

            // calculating the numbers
            double numAndSumSabers = Math.Ceiling(countOfStudents * 1.10) * pricelightSabers;
            double numAndSumRobes = countOfStudents * priceRobes;
            double numFreeBelts = (countOfStudents / 6);
            
            double numAndSumBelts = (countOfStudents - numFreeBelts) * priceBelts;
            double totalPrice = numAndSumBelts + numAndSumRobes + numAndSumSabers;

            if (totalPrice <= budget)
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
            else
            {
                totalPrice = Math.Abs(totalPrice - budget);
                Console.WriteLine($"John will need {totalPrice:f2}lv more.");
            }
        }
    }
}
