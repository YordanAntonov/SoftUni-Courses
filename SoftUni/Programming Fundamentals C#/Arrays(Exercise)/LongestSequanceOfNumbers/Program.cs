using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestSequanceOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] array = Console.ReadLine().Split();
            string maxSeq = "";
            int count = 0;
            int currentCount = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == array[i + 1]) 
                {
                    currentCount++;
                    if (currentCount > count)
                    {
                        count = currentCount;
                        maxSeq = array[i];
                    }
                }
                else
                {
                    currentCount = 0;
                }

            }
            for (int j = 0; j <= count; j++)
            {
                Console.Write($"{maxSeq} ");
            } 
        }
    }
}
