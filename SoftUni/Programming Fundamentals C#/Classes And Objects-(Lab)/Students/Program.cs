using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Students> studentsList = new List<Students>();
            string command = Console.ReadLine();

            while (command != "end")
            {
                string[] studentInfo = command.Split();
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                int age = int.Parse(studentInfo[2]);
                string homeTown = studentInfo[3];

                Students student = new Students (firstName, lastName, age, homeTown);
                studentsList.Add(student);

                command = Console.ReadLine();
            }
            string checkTown = Console.ReadLine();

            foreach (Students student in studentsList)
            {
                if (checkTown == student.HomeTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }

    }

    class Students
    {
        public Students(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
