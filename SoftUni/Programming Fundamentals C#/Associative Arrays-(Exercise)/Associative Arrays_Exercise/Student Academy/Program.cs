using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfLines = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> studentStats = new Dictionary<string, List<double>>();

            for (int i = 0; i < numOfLines; i++)
            {
                string studentName = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (!DoesStudentExist(studentName, studentStats))
                {
                    studentStats[studentName] = new List<double>();
                }

                studentStats[studentName].Add(grade);
            }

            

            foreach (KeyValuePair<string, List<double>> student in studentStats.Where(s => s.Value.Average() >= 4.50))
            {
                double studentAvg = student.Value.Average();

                Console.WriteLine($"{student.Key} -> {studentAvg:f2}");
            }
        }

        static bool DoesStudentExist(string studentName, Dictionary<string, List<double>> studentStats) => studentStats.ContainsKey(studentName);
    }
}
