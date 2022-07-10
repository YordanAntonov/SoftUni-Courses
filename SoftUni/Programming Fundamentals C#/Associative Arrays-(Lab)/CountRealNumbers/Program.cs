using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountRealNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> listOfIntegers = Console.ReadLine().Split().Select(int.Parse).ToList();
            SortedDictionary<int, int> sortedList = new SortedDictionary<int, int>();
            foreach (int number in listOfIntegers)
            {
                if (!sortedList.ContainsKey(number))
                {
                    sortedList[number] = 0;
                }
                sortedList[number]++;
            }

            foreach (var number in sortedList)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}
