using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicationTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int multip = int.Parse(Console.ReadLine());

            if (multip > 10)
            {
                int result = 0;
                result = num * multip;
                Console.WriteLine($"{num} X {multip} = {result}");
            }
            else
            {
                for (int i = multip; i <= 10; i++)
                {
                    int result = 0;
                    result = num * i;
                    Console.WriteLine($"{num} X {i} = {result}");
                }
            }

        }
    }
}
