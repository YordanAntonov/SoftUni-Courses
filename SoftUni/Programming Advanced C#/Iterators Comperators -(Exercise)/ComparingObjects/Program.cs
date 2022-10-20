using System;
using System.Collections.Generic;
using System.Net.Cache;

namespace ComparingObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string command;

            while ((command = Console.ReadLine()) != "END")
            {
                string[] personProps = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person
                {
                    Name = personProps[0],
                    Age = int.Parse(personProps[1]),
                    Town = personProps[2]
                };
                people.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            Person personToCompare = people[index];

            int equalCount = 0;
            int diffCount = 0;

            foreach (var item in people)
            {
                if (item.CompareTo(personToCompare) == 0)
                {
                    equalCount++;
                }
                else
                {
                    diffCount++;
                }
            }

            if (equalCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalCount} {diffCount} { people.Count}");
            }
        }
    }
}
