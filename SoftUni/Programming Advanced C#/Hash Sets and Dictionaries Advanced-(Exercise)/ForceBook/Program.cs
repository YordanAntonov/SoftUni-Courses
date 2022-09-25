using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> sidesAndUsers = new SortedDictionary<string, SortedSet<string>>();


            string input = Console.ReadLine();

            while (input != "Lumpawaroo")
            {

                if (input.Contains('|'))
                {
                    string[] tokens = input.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = tokens[0];
                    string forceUser = tokens[1];

                    if (!sidesAndUsers.Values.Any(x => x.Contains(forceUser)))
                    {
                        if (!sidesAndUsers.ContainsKey(forceSide))
                        {
                            sidesAndUsers.Add(forceSide, new SortedSet<string>());
                        }

                        sidesAndUsers[forceSide].Add(forceUser);
                    }
                }
                else
                {
                    string[] tokens = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                    string forceSide = tokens[1];
                    string forceUser = tokens[0];

                    foreach (var user in sidesAndUsers)
                    {
                        if (user.Value.Contains(forceUser))
                        {
                            user.Value.Remove(forceUser);
                            break;
                        }
                    }

                    if (!sidesAndUsers.ContainsKey(forceSide))
                    {
                        sidesAndUsers.Add(forceSide, new SortedSet<string>());
                    }

                    sidesAndUsers[forceSide].Add(forceUser);
                    Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                }

                input = Console.ReadLine();
            }

            var orderedSides = sidesAndUsers.OrderByDescending(x => x.Value.Count);

            foreach (var side in orderedSides)
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    foreach (var user in side.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }
    }
}
