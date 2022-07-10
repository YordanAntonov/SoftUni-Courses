using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputCommands = Console.ReadLine().Split(new[] { " : " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string, List<string>> courseInfo = new Dictionary<string, List<string>>();

            while (inputCommands[0] != "end")
            {
                string courseName = inputCommands[0];
                string studentName = inputCommands[1];

                if (!CheckForCourse(courseName, courseInfo))
                {
                    courseInfo[courseName] = new List<string>();
                }
                courseInfo[courseName].Add(studentName);

                inputCommands = Console.ReadLine().Split(new[] { " : " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var course in courseInfo)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var student in course.Value)
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }

        static bool CheckForCourse(string course, Dictionary<string, List<string>> courseInfo) => courseInfo.ContainsKey(course);
    }
}
