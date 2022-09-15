using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());
            string input = Console.ReadLine().ToLower();

            while (input != "end")
            {
                string[] tokens = input.Split();
                string action = tokens[0];

                switch (action)
                {
                    case "add":
                        int numOne = int.Parse(tokens[1]);
                        int numTwo = int.Parse(tokens[2]);
                        numbers.Push(numOne);
                        numbers.Push(numTwo);
                        break;

                    case "remove":
                        int iterator = int.Parse(tokens[1]);
                        if (numbers.Count >= iterator)
                        {
                            for (int i = 0; i < iterator; i++)
                            {
                                numbers.Pop();
                            }
                        }
                        break;
                }

                input = Console.ReadLine().ToLower();
            }
            int result = numbers.Sum();
            Console.WriteLine($"Sum: {result}");
        }
    }
}
