using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPower
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double _base = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine(GetPowerUp(_base, power));

        }
        static double GetPowerUp(double _base, int power)
        {
            double result = 1;
            for (int i = 0; i < power; i++)
            {
                result *= _base;
            }
            return result;
        }
    }
}
