using System;
using System.Collections.Generic;
using System.Linq;

namespace TriFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, int, bool> stringChecker = (word, threshold) =>
            {
                if (word.Sum(ch => ch) >= threshold)
                {
                    return true;
                }
                return false;
            };
            Func<List<string>, Func<string, int, bool>, int, string> filterFunc = (word, stringChecker, sum) =>
            {
                foreach (var name in word)
                {
                    if (stringChecker(name, sum) == true)
                    {
                        return name;
                    }
                }
                return string.Empty;
            };

            int sum = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string result = filterFunc(names, stringChecker, sum);

            Console.WriteLine(result);

        }


    }
}
