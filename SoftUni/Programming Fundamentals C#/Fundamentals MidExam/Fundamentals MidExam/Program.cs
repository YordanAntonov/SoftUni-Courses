using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals_MidExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budged = double.Parse(Console.ReadLine());
            int studentsNumber = int.Parse(Console.ReadLine());
            double priceForFlour = double.Parse(Console.ReadLine());
            double priceForEgg = double.Parse(Console.ReadLine());
            double priceForApron = double.Parse(Console.ReadLine());

            double numAndSumOfAprons = Math.Ceiling(studentsNumber + (studentsNumber * 0.20)) * priceForApron;
            double numAndSumOfEggs = (priceForEgg * 10) * studentsNumber;
            double numOfFreeFlour = studentsNumber / 5;

            double numAndSumOfFlour = (studentsNumber - numOfFreeFlour) * priceForFlour;
            double totalPriceForItems = numAndSumOfAprons + numAndSumOfEggs + numAndSumOfFlour;

            if (totalPriceForItems <= budged)
            {
                Console.WriteLine($"Items purchased for {totalPriceForItems:f2}$.");
            }
            else
            {
                totalPriceForItems -= budged;
                Console.WriteLine($"{totalPriceForItems:f2}$ more needed.");
            }
        }
    }
}
