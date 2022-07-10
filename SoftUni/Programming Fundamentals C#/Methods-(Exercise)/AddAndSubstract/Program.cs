using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddAndSubstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            int num3 = int.Parse(Console.ReadLine());
            int adedResult = SubstractFirstTwo(num1, num2);
            int result = SubstractFromResult(adedResult, num3);
            ShowResult(result);

        }
        static int SubstractFirstTwo(int num1, int num2) => num1 + num2;

        static int SubstractFromResult(int result, int num3) => result - num3;

        static void ShowResult(int result) => Console.WriteLine(result);
    }
}
