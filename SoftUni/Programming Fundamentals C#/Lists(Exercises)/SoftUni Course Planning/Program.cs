using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Course_Planning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> courses = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = "";

            while ((command = Console.ReadLine()) != "course start")
            {
                string[] tokens = command.Split(':');
                string action = tokens[0];
                string course = tokens[1];
                switch (action)
                {
                    case "Add":
                        AddCourse(course, courses);
                        break;
                    case "Insert":
                        int index = int.Parse(tokens[2]);
                        InsertCourse(course, index, courses);
                        break;
                    case "Remove":
                        RemoveCourse(course, courses);
                        break;
                    case "Swap":
                        string secondCourse = tokens[2];
                        SwapCourses(course, secondCourse, courses);
                        break;
                    case "Exercise":
                        AddExercise(course, courses);
                        break;
                }
            }
            int counter = 1;
            foreach (string course in courses)
            {
                Console.WriteLine($"{counter}.{course}");
                counter++;
            }
        }

        private static void AddExercise(string course, List<string> courses)
        {

            string exercise = ($"{course}-Exercise");
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i] == course)
                {
                    courses.Insert(i + 1, exercise);

                    return;
                }
            }

            courses.Add(course);
            courses.Add(exercise);

        }

        private static void SwapCourses(string course, string secondCourse, List<string> courses)
        {
            string firstCourse = course;
            string secondaryCourse = secondCourse;


            if (courses.Contains(course) && courses.Contains(secondCourse))
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i] == course)
                    {
                        courses[i] = secondaryCourse;
                    }
                    else if (courses[i] == secondCourse)
                    {
                        courses[i] = firstCourse;
                    }
                }
            }

            int courseOne = courses.IndexOf(course);
            int courseTwo = courses.IndexOf(secondCourse);

            if (courses.Contains(firstCourse + "-Exercise") && courses.Contains(secondCourse))
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i] == firstCourse + "-Exercise")
                    {
                        courses.RemoveAt(i);
                        courses.Insert(courseOne + 1, firstCourse + "-Exercise");
                    }
                }
            }
            if (courses.Contains(secondaryCourse + "-Exercise") && courses.Contains(firstCourse))
            {
                for (int i = 0; i < courses.Count; i++)
                {
                    if (courses[i] == secondaryCourse + "-Exercise")
                    {
                        courses.RemoveAt(i);
                        courses.Insert(courseTwo + 1, secondaryCourse + "-Exercise");
                    }
                }
            }

        }

        private static void RemoveCourse(string course, List<string> courses)
        {
            int indexOfExer = courses.IndexOf(course);
            if (indexOfExer + 1 < courses.Count)
            {
                if (courses[indexOfExer + 1] == ($"{course}-Exercise"))
                {
                    courses.RemoveRange(indexOfExer, 2);
                }
                else
                {
                    courses.Remove(course);
                }
            }
            else
            {
                courses.Remove(course);
            }
        }

        private static void InsertCourse(string course, int index, List<string> courses)
        {
            if (courses.Contains(course))
            {
                return;
            }
            else
            {
                if (index >= 0 && index < courses.Count)
                {
                    courses.Insert(index, course);
                }
            }
        }

        private static void AddCourse(string course, List<string> courses)
        {
            if (courses.Contains(course))
            {
                return;
            }
            else
            {
                courses.Add(course);
            }
        }
    }
}
