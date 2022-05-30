using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTypesAndVariables_Exercise_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int divisor = int.Parse(Console.ReadLine());
            int multiplier = int.Parse(Console.ReadLine());

            int result = (firstNum + secondNum) / divisor * multiplier;
            Console.WriteLine(result);

        }
    }
}
