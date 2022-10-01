using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Predicate_for_Names
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<string>, Predicate<string>, List<string>> nameFilter = (names, match) =>
            {
                List<string> matchingNames = new List<string>();
                foreach (var name in names)
                {
                    if (match(name))
                    {
                        matchingNames.Add(name);
                    }
                }
                return matchingNames;
            };

            int length = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            names = nameFilter(names, x => x.Length <= length);

            Console.WriteLine(string.Join(Environment.NewLine, names));

        }
    }
}
