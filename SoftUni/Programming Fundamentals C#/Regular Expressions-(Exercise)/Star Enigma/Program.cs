using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Star_Enigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            List<string> atackingPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();

            for (int i = 0; i < number; i++)
            {
                StringBuilder newMessage = new StringBuilder();
                string message = Console.ReadLine();
                int checkCount = message.ToLower().Count(ch => ch == 's' || ch == 'a' || ch == 't' || ch == 'r');

                foreach (char ch in message)
                {
                    char newChar = (char)(ch - checkCount);
                    newMessage.Append(newChar);
                }
                string pattern = @"@(?<name>[A-z]+)[^@\- !:>]*:(?<population>[\d]+)[^@\- !:>]*!(?<atacktype>[A,D])![^@\- !:>]*->(?<soldiercount>[\d]+)";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(newMessage.ToString());
                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    char atackType = char.Parse(match.Groups["atacktype"].Value);
                    if (atackType == 'A')
                    {
                        atackingPlanets.Add(name);
                    }
                    else
                    {
                        destroyedPlanets.Add(name);
                    }
                }
            }
            atackingPlanets.Sort();
            destroyedPlanets.Sort();

            Console.WriteLine($"Attacked planets: {atackingPlanets.Count}");
            if (atackingPlanets.Count > 0)
            {
                atackingPlanets.ForEach(planetName => Console.WriteLine($"-> {planetName}"));
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            if (destroyedPlanets.Count > 0)
            {
                destroyedPlanets.ForEach(planetName => Console.WriteLine($"-> {planetName}"));
            }

        }
    }
}
