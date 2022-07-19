using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Courses_Planning_2_
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
                string function = tokens[0];
                string lessonTitle = tokens[1];

                if (function == "Add")
                {
                    if (!courses.Contains(lessonTitle))
                    {
                        courses.Add(lessonTitle);
                    }
                }
                else if (function == "Insert")
                {
                    int insertIndex = int.Parse(tokens[2]);

                    if (insertIndex >= 0 && insertIndex < courses.Count)
                    {
                        if (!courses.Contains(lessonTitle))
                        {
                            courses.Insert(insertIndex, lessonTitle);
                        }
                    }
                }
                else if (function == "Remove")
                {
                    string exercise = $"{lessonTitle}-Exercise";
                    bool isThereLesson = courses.Contains(lessonTitle);
                    bool isThereExercise = courses.Contains(exercise);
                    int index = courses.IndexOf(lessonTitle);

                    if (index >= 0 && index < courses.Count)
                    {
                        if (isThereLesson && isThereExercise)
                        {
                            courses.RemoveAt(index + 1);
                            courses.Remove(lessonTitle);
                        }
                        else if (isThereLesson && !isThereExercise)
                        {
                            courses.RemoveAt(index);
                        }
                    }

                }
                else if (function == "Swap")
                {
                    string secondLessonTitle = tokens[2];

                    int indexOfFirstLesson = courses.IndexOf(lessonTitle); // loops => index is 1 => index is 3
                    int indexOfSecondLesson = courses.IndexOf(secondLessonTitle); // methods => index is 3 => indes is 1

                    if (indexOfFirstLesson >= 0 && indexOfFirstLesson < courses.Count
                        && indexOfSecondLesson >= 0 && indexOfSecondLesson < courses.Count)
                    {

                        if (courses.Contains(lessonTitle) && courses.Contains(secondLessonTitle))
                        {
                            for (int i = 0; i < courses.Count; i++)
                            {
                                if (courses[i] == lessonTitle)
                                {
                                    courses[i] = secondLessonTitle;
                                }
                                else if (courses[i] == secondLessonTitle)
                                {
                                    courses[i] = lessonTitle;
                                }
                            }
                        }

                        int courseOne = courses.IndexOf(lessonTitle);
                        int courseTwo = courses.IndexOf(secondLessonTitle);

                        if (courses.Contains(lessonTitle + "-Exercise") && courses.Contains(secondLessonTitle))
                        {
                            for (int i = 0; i < courses.Count; i++)
                            {
                                if (courses[i] == lessonTitle + "-Exercise")
                                {
                                    courses.RemoveAt(i);
                                    courses.Insert(courseOne + 1, lessonTitle + "-Exercise");
                                }
                            }
                        }
                        if (courses.Contains(secondLessonTitle + "-Exercise") && courses.Contains(lessonTitle))
                        {
                            for (int i = 0; i < courses.Count; i++)
                            {
                                if (courses[i] == secondLessonTitle + "-Exercise")
                                {
                                    courses.RemoveAt(i);
                                    courses.Insert(courseTwo + 1, secondLessonTitle + "-Exercise");
                                }
                            }
                        }
                    }


                }
                else if (function == "Exercise")
                {
                    string exercise = $"{lessonTitle}-Exercise";
                    int index = courses.IndexOf(lessonTitle);
                    bool isThereTheLesson = courses.Contains(lessonTitle);
                    bool isThereTheExercise = courses.Contains(exercise);

                    if (isThereTheLesson && !isThereTheExercise)
                    {
                        if (index >= 0 && index < courses.Count)
                        {
                            courses.Insert(index + 1, exercise);
                        }
                    }
                    else if (!isThereTheLesson)
                    {
                        courses.Add(lessonTitle);
                        courses.Add(exercise);
                    }
                }

            }
            for (int i = 0; i <= courses.Count - 1; i++)
            {
                Console.WriteLine($"{i + 1}.{courses[i]}");
            }
        }
    }
}
