using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contest_Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestAndPassword = new Dictionary<string, string>();
            Dictionary<string, List<Contests>> userAndContest = new Dictionary<string, List<Contests>>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] tokens = input.Split(new[] {':'},StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                if (!contestAndPassword.ContainsKey(contest))
                {
                    contestAndPassword[contest] = password;
                }
                input = Console.ReadLine();
            }

            string info = Console.ReadLine();
            while (info != "end of submission")
            {
                string[] tokens = info.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contestAndPassword.ContainsKey(contest) && contestAndPassword[contest].Contains(password))
                {
                    if (!userAndContest.ContainsKey(username))
                    {
                        Contests contestant = new Contests (username, contest, points);
                        userAndContest[username] = new List<Contests>();
                        userAndContest[username].Add(contestant);
                    }
                    else
                    {
                        Contests currContestant = userAndContest[username].First(c => c.Name == username);
                        if (currContestant.Contest != contest)
                        {
                            Contests newContest = new Contests (username, contest, points);
                            userAndContest[username].Add(newContest);
                        }
                        else
                        {
                            if (currContestant.Score < points)
                            {
                                currContestant.Score += points;
                            }
                        }
                    }
                }

                info = Console.ReadLine();
            }
            int maxValue = int.MinValue;
            foreach (var contestant in userAndContest)
            {
                
            }
            
        }
    }
    class Contests
    {
        public Contests(string name, string contest, int score)
        {
            Name = name;

            Contest = contest;

            Score = score;
        }
        public string Name { get; set; }
        public string Contest { get; set; }
        public int Score { get; set; }
    }

    
}
