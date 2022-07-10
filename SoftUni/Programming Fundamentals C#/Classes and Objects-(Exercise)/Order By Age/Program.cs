using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_By_Age
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string personInfo = "";
            List<Person> personList = new List<Person>();

            while ((personInfo = Console.ReadLine()) != "End")
            {
                string[] info = personInfo.Split();
                string name = info[0];
                string id = info[1];
                int age = int.Parse(info[2]);

                if (personList.Any(person => person.Id == id))
                {
                    Person desiredPerson = personList.FirstOrDefault(person => person.Id == id);
                    desiredPerson.ChangeData(name, age);
                }
                else
                {
                    Person person = new Person(name, id, age);
                    personList.Add(person);
                }

            }
            List<Person> orderedByAge = personList.OrderBy(person => person.Age).ToList();

            foreach (Person person in orderedByAge)
            {
                Console.WriteLine(person);
            }
        }
    }

    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public void ChangeData(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
