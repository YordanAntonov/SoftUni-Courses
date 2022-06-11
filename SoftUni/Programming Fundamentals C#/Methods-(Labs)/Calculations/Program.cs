using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            switch (command)
            {
                case "add":
                    CommandAdd(firstNum, secondNum);
                    break;
                case "multiply":
                    CommandMultiply(firstNum, secondNum);
                    break;
                case "substract":
                    CommandSubstract(firstNum, secondNum);
                    break;
                case "divide":
                    CommandDivide(firstNum, secondNum);
                    break;
            }

        }

        static void CommandAdd(int firstNum, int secondNum)
        {
            int result = firstNum + secondNum;
            Console.WriteLine(result);
        }
        static void CommandMultiply(int firstNum, int secondNum)
        {
            int result = firstNum * secondNum;
            Console.WriteLine(result);
        }
        static void CommandSubstract(int firstNum, int secondNum)
        {
            int result = firstNum - secondNum;
            Console.WriteLine(result);
        }
        static void CommandDivide(int firstNum, int secondNum)
        {
            double result = (double)firstNum / secondNum;
            Console.WriteLine(result);
        }
    }
}
