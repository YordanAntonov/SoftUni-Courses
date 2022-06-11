using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalCalculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNum = double.Parse(Console.ReadLine());
            char sign = char.Parse(Console.ReadLine());
            double secondNum = double.Parse(Console.ReadLine());

            switch (sign)
            {
                case '*':
                    Console.WriteLine(GetMultiplication(firstNum, secondNum));
                    break;
                case '/':
                    Console.WriteLine(GetDivision(firstNum, secondNum));
                    break;
                case '+':
                    Console.WriteLine(GetAdditive(firstNum, secondNum));
                    break;
                case '-':
                    Console.WriteLine(GetSubstraction(firstNum, secondNum));
                    break;
            }

        }

        // *
        static double GetMultiplication(double firstNum, double secondNum)
        {
            double result = firstNum * secondNum;
            return result;
        } 
        static double GetDivision(double firstNum, double secondNum)
        {
            double result = firstNum / secondNum;
            return result;
        }static double GetAdditive(double firstNum, double secondNum)
        {
            double result = firstNum + secondNum;
            return result;
        }static double GetSubstraction(double firstNum, double secondNum)
        {
            double result = firstNum - secondNum;
            return result;
        }


    }
}
