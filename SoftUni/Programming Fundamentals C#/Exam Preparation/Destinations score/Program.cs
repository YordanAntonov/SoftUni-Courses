using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Destinations_score
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string destinations = Console.ReadLine();
            string pattern = @"(?<grp>[=|\/])(?<text>[A-Z][A-Za-z]{2,})\k<grp>";

            List<string> destinationsList = new List<string>();
            Regex regex = new Regex(pattern);

            MatchCollection destinationMatches = regex.Matches(destinations);
            int sum = 0;
            foreach (Match match in destinationMatches)
            {
                string dest = match.Groups["text"].Value;
                sum += dest.Length;
                destinationsList.Add(dest);
            }

            Console.WriteLine($"Destinations: {string.Join(", ", destinationsList)}");
            Console.WriteLine($"Travel Points: {sum}");
        }
    }
}
