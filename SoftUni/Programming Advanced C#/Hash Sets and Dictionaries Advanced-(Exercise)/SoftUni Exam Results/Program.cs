using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> examResults = new SortedDictionary<string, int>();
            SortedDictionary<string, int> languagesAndSubmissions = new SortedDictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] tokens = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string username = tokens[0];

                if (tokens[1] == "banned")
                {
                    examResults.Remove(username);
                    input = Console.ReadLine();

                    continue;
                }

                //Dont forget to add if statment for banned people before this code below!!!
                string language = tokens[1];
                int point = int.Parse(tokens[2]);

                if (!examResults.ContainsKey(username))
                {
                    examResults.Add(username, 0);
                }

                if (examResults[username] < point)
                {
                    examResults[username] = point;
                }

                UpdateLanguageCount(languagesAndSubmissions, language);

                input = Console.ReadLine();
            }

            var sortedResults = examResults.OrderByDescending(x => x.Value);
            var orderedLanguages = languagesAndSubmissions.OrderByDescending(x => x.Value);

            Console.WriteLine("Results:");
            foreach (var result in sortedResults)
            {
                Console.WriteLine($"{result.Key} | {result.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var language in orderedLanguages)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }

        }

        private static void UpdateLanguageCount(SortedDictionary<string, int> languagesAndSubmissions, string language)
        {
            if (!languagesAndSubmissions.ContainsKey(language))
            {
                languagesAndSubmissions.Add(language, 0);
            }

            languagesAndSubmissions[language]++;

        }
    }
}
