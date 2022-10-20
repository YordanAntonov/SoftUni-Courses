using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputString = Console.ReadLine();

            string[] tokens = Console.ReadLine().Split(':').ToArray();

            while (tokens[0] != "Travel")
            {
                string mainCmd = tokens[0];
                switch (mainCmd)
                {
                    case "Add Stop":
                        int index = int.Parse(tokens[1]);
                        string addString = tokens[2];
                        if (index >= 0 && index <= inputString.Length - 1)
                        {
                            inputString = inputString.Insert(index, addString);
                        }
                        break;

                    case "Remove Stop":
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        if (startIndex >= 0 && startIndex < inputString.Length
                            && endIndex >= 0 && endIndex < inputString.Length)
                        {
                            inputString = inputString.Remove(startIndex, (endIndex - startIndex) + 1);
                        }
                        break;

                    case "Switch":
                        string oldString = tokens[1];
                        string newString = tokens[2];
                        if (inputString.Contains(oldString))
                        {
                            inputString = inputString.Replace(oldString, newString);
                        }
                        break;
                }
                Console.WriteLine(inputString);
                tokens = Console.ReadLine().Split(':').ToArray();
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {inputString}");
        }
    }
}
