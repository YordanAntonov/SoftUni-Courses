using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string namesPattern = @"(?<names>[A-Za-z])";
            string numbersPattern = @"(?<numbers>\d)";
            Dictionary<string, int> racers = new Dictionary<string, int>();

            List<string> participants = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();

            Regex namesRegex = new Regex(namesPattern);
            Regex numbersRegex = new Regex(numbersPattern);

            List<string> validParticipants = new List<string>();
            string command = "";

            while ((command = Console.ReadLine()) != "end of race")
            {
                MatchCollection matches = namesRegex.Matches(command);
                MatchCollection numbersMatch = numbersRegex.Matches(command);
                string racerName = "";
                int kmSum = 0;
                if (namesRegex.IsMatch(command))
                {
                    foreach (Match letter in matches)
                    {
                        racerName += letter;
                    }
                }

                if (!participants.Contains(racerName)) continue;


                if (numbersRegex.IsMatch(command))
                {
                    foreach (Match num in numbersMatch)
                    {
                        kmSum += int.Parse(num.ToString());
                    }
                }

                if (!racers.ContainsKey(racerName))
                {
                    racers.Add(racerName, kmSum);
                }
                else
                {
                    racers[racerName] += kmSum;
                }
            }
            // We have to take only the first 3 places!
            participants = racers.OrderByDescending(x => x.Value).Select(racer => racer.Key).ToList();
            string firstPlace = participants[0];
            string secondPlace = participants[1];
            string thirdPlace = participants[2];

            Console.WriteLine($"1st place: {firstPlace}");
            Console.WriteLine($"2nd place: {secondPlace}");
            Console.WriteLine($"3rd place: {thirdPlace}");

            //Alternative solution to sorting!
            //string firstPlace = participants.Take(1).First();
            //participants.RemoveAt(0);
            //string secondPlace = participants.Take(1).First();
            //participants.RemoveAt(0);
            //string thirdPlace = participants.Take(1).First();
        }
    }
}
