using SortPersonsByNameAndAge;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        public static void Main()
        {
            var lines = int.Parse(Console.ReadLine());
            var persons = new List<Person>();
            for (int i = 0; i < lines; i++)
            {
                try
                {
                    var cmdArgs = Console.ReadLine().Split();
                    var person = new Person(cmdArgs[0],
                    cmdArgs[1],
                   int.Parse(cmdArgs[2]),
                   decimal.Parse(cmdArgs[3]));
                    persons.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine(team);
        }
    }
}
