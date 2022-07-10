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
            //"{first name} {second name} {grade}
            int numberOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] information = Console.ReadLine().Split();
                Student student = new Student(information[0], information[1], double.Parse(information[2]));
                students.Add(student);
            }
            List<Student> orderedStudents = students.OrderByDescending(student => student.Grade).ToList();

            orderedStudents.ForEach(student => Console.WriteLine(student));
        }
    }
    class Student
    {
        public Student(string firstName, string lastName, double grade)        
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
        }


        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString() => $"{FirstName} {LastName}: {Grade:f2}"; 
        
    }
}
