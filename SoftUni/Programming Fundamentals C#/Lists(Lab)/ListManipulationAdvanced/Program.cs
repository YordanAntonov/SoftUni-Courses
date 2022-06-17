using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string[] commands = Console.ReadLine().Split();
            bool changesAreMade = false;
            while (commands[0] != "end")
            {
                if (commands[0] == "Add")
                {
                    int movingComand = int.Parse(commands[1]);
                    numbers.Add(movingComand);
                    changesAreMade = true;
                }
                else if (commands[0] == "Remove")
                {
                    int movingComand = int.Parse(commands[1]);
                    changesAreMade = true;
                    numbers.Remove(movingComand);
                }
                else if (commands[0] == "RemoveAt")
                {
                    int movingComand = int.Parse(commands[1]);
                    changesAreMade = true;
                    numbers.RemoveAt(movingComand);
                }
                else if (commands[0] == "Insert")
                {
                    int movingComand = int.Parse(commands[1]);
                    changesAreMade = true;
                    int supportCommand = int.Parse(commands[2]);
                    numbers.Insert(supportCommand, movingComand);
                }
                else if (commands[0] == "Contains")
                {
                    int movingComand = int.Parse(commands[1]);
                    IsItInTheList(numbers, movingComand);
                }
                else if (commands[0] == "PrintEven")
                {
                    List<int> evenNums = GetEvenNumbers(numbers);
                    Console.WriteLine(string.Join(" ", evenNums));
                }
                else if (commands[0] == "PrintOdd")
                {
                    List<int> oddNums = GetOddNumbers(numbers);
                    Console.WriteLine(string.Join(" ", oddNums));
                }
                else if (commands[0] == "GetSum")
                {
                    int sum = GetSumOfNumbers(numbers);
                    Console.WriteLine(sum);
                }
                else if (commands[0] == "Filter")
                {
                    string condition = commands[1];
                    int movingComand = int.Parse(commands[2]);
                    List<int> filteredNumbers = FilterNumbers(numbers, condition, movingComand);
                    Console.WriteLine(string.Join(" ", filteredNumbers));
                }

                commands = Console.ReadLine().Split();
            }

            if (changesAreMade)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
        static List<int> GetEvenNumbers(List<int> numbers)
        {
            List<int> result = new List<int>();
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    result.Add(number);
                }
            }
            return result;
        }static List<int> GetOddNumbers(List<int> numbers)
        {
            List<int> result = new List<int>();
            foreach (int number in numbers)
            {
                if (number % 2 != 0)
                {
                    result.Add(number);
                }
            }
            return result;
        }

        static void IsItInTheList(List<int> numbers, int checkNumber)
        {
            bool listContainsNumber = numbers.Contains(checkNumber);
            if (!listContainsNumber)
            {
                Console.WriteLine("No such number");
            }
            else
            {
                Console.WriteLine("Yes");
            }
        }

        static int GetSumOfNumbers(List<int> numbers)
        {
            int result = numbers.Sum();
            return result;
        }

        static List<int> FilterNumbers(List<int> numbers, string condition, int number)
        {
            List<int>conditionNumbers = new List<int>();
            if (condition == ">")
            {
                foreach (int num in numbers)
                {
                    if (num > number)
                    {
                        conditionNumbers.Add(num);
                    }
                }
            }
            else if (condition == "<")
            {
                foreach (int num in numbers)
                {
                    if (num < number)
                    {
                        conditionNumbers.Add(num);
                    }
                }
            }
            else if (condition == "<=")
            {
                foreach (int num in numbers)
                {
                    if (num <= number)
                    {
                        conditionNumbers.Add(num);
                    }
                }
            }
            else if (condition == ">=")
            {
                foreach (int num in numbers)
                {
                    if (num >= number)
                    {
                        conditionNumbers.Add(num);
                    }
                }
            }
            return conditionNumbers;
        }

    }

}
