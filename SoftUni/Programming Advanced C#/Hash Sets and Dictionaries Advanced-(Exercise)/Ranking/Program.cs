using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsAndPasswords = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> usersContests = new SortedDictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();

            while (command != "end of contests")
            {
                string[] tokens = command.Split(new[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];

                if (!contestsAndPasswords.ContainsKey(contest))
                {
                    contestsAndPasswords.Add(contest, password);
                }

                command = Console.ReadLine();
            }

            string secondCommand = Console.ReadLine();

            while (secondCommand != "end of submissions")
            {
                string[] tokens = secondCommand.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);


                if (contestsAndPasswords.ContainsKey(contest) && password == contestsAndPasswords[contest])
                {
                    if (!usersContests.ContainsKey(username))
                    {
                        usersContests.Add(username, new Dictionary<string, int>());
                        usersContests[username].Add(contest, points);
                    }
                    else
                    {
                        if (!usersContests[username].ContainsKey(contest))
                        {
                            usersContests[username].Add(contest, points);
                        }
                        else
                        {
                            if (points > usersContests[username][contest])
                            {
                                usersContests[username][contest] = points;
                            }
                        }
                    }
                }
                secondCommand = Console.ReadLine();
            }

            string bestCandidate = usersContests.OrderByDescending(x => x.Value.Values.Sum()).First().Key;
            int bestCandidatePoints = usersContests[bestCandidate].Values.Sum();
            

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidatePoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var contestant in usersContests)
            {
                var orderedByPoints = contestant.Value.OrderByDescending(x => x.Value);
                Console.WriteLine($"{contestant.Key}");
                foreach (var contest in orderedByPoints)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
