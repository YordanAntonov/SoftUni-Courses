using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks.Dataflow;

namespace Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, List<int>> add = number =>
            {
                for (int i = 0; i < number.Count; i++)
                {
                    number[i]++;
                }
                return number;
            };
            Func<List<int>, List<int>> subtract = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i]--;
                }
                return numbers;
            };
            Func<List<int>, List<int>> multiply = numbers =>
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] *= 2;
                }
                return numbers;
            };
            Action<List<int>> print = numbers =>
            {
                Console.WriteLine(String.Join(" ", numbers));
            };


            List<int> number = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        add(number);
                        break;
                    case "subtract":
                        subtract(number);
                        break;
                    case "multiply":
                        multiply(number);
                        break;
                    case "print":
                        print(number);
                        break;
                }

            }
        }
    }
}
