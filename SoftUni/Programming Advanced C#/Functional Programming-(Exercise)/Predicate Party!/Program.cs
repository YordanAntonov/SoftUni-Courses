using System;
using System.Collections.Generic;
using System.Linq;

namespace Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> members = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Party!")
                {
                    break;
                }

                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string filter = tokens[1];
                string value = tokens[2];

                if (action == "Remove")
                {
                    members.RemoveAll(GetPredicate(filter, value));
                }
                else
                {
                    List<string> doubleNames = members.FindAll(GetPredicate(filter, value));


                    int index = members.FindIndex(GetPredicate(filter, value));

                    if (index >= 0)
                    {
                        members.InsertRange(index, doubleNames);
                    }
                    
                }
            }

            if (members.Any())
            {
                Console.WriteLine($"{string.Join(", ", members)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string filter, string value)
        {
            switch (filter)
            {
                case "StartsWith":
                    return p => p.StartsWith(value);
                case "EndsWith":
                    return p => p.EndsWith(value);
                case "Length":
                    return p => p.Length == int.Parse(value);
                default:
                    return null;
            }
        }
    }
}
