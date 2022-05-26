using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OddNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum = 0;
            for (int i = 1; i <= n; i++)
            {
                int currOddNum = (2 * i) - 1;
                Console.WriteLine(currOddNum);
                sum += currOddNum;
            }
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
