using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }
            
            List<Person> list = family.MembersList.Where(x => x.Age > 30).OrderBy(p => p.Name).ToList();

            foreach (var person in list)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }

        }
    }
}
