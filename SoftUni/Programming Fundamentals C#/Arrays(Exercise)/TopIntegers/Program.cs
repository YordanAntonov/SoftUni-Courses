using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopIntegers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();


            for (int i = 0; i < numbers.Length; i++)
            {
                int currentComperable = numbers[i];
                bool theNumIsBigger = true;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    int currentComparator = numbers[j];
                    if (currentComperable <= currentComparator)
                    {
                        theNumIsBigger = false;
                        break;
                    }
                }
                if (theNumIsBigger)
                {
                    Console.Write($"{currentComperable} ");
                }

            }
        }
    }
}
