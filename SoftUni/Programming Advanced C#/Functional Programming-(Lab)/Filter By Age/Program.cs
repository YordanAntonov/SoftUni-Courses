using System;
using System.Collections.Generic;
using System.Linq;

namespace Filter_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, Person, int, bool> conditionChecker = (c, p, a) => c == "older" ? p.Age >= a : p.Age < a;


            int iterations = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();



            for (int i = 0; i < iterations; i++)
            {
                string[] personInfo = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);
                Person person = new Person(int.Parse(personInfo[1]), personInfo[0]);

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int ageThreshold = int.Parse(Console.ReadLine());
            string[] printInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            people = people.Where(p => conditionChecker(condition, p, ageThreshold)).ToList();

            if (printInfo.Length == 1)
            {
                switch (printInfo[0])
                {
                    case "name":
                        foreach (var person in people)
                        {
                            Console.WriteLine($"{person.Name}");
                        }
                        break;
                    case "age":
                        foreach (var person in people)
                        {
                            Console.WriteLine($"{person.Age}");
                        }
                        break;
                }
            }
            else
            {
                foreach (var person in people)
                {
                    Console.WriteLine($"{person.Name} - {person.Age}");
                }
            }




        }
    }

    class Person
    {
        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }

        public int Age { get; set; }
        public string Name { get; set; }
    }
}
