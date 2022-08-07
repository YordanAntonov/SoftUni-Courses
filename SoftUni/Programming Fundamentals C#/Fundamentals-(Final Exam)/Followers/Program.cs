using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Followers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, KeyValuePair<int, int>> userRecord = new Dictionary<string, KeyValuePair<int, int>>();

            string command = Console.ReadLine();

            while (command != "Log out")
            {
                string[] tokens = command.Split(new[] {": "}, StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string username = tokens[1];

                switch (action)
                {
                    case "New follower":
                        if (!userRecord.ContainsKey(username))
                        {
                            userRecord[username] = new KeyValuePair<int, int>(0, 0);
                        }
                        else
                        {
                            command = Console.ReadLine();
                            continue;
                        }
                        break;

                    case "Like":
                        int countOfLikes = int.Parse(tokens[2]);
                        if (!userRecord.ContainsKey(username))
                        {
                            userRecord[username] = new KeyValuePair<int, int>(countOfLikes, 0);
                        }
                        else
                        {
                            KeyValuePair<int, int> userValues = userRecord[username];
                            int currLikes = userValues.Key;
                            int currComments = userValues.Value;
                            currLikes += countOfLikes;
                            userRecord[username] = new KeyValuePair<int, int>(currLikes, currComments);
                        }
                        break;
                    case "Comment":
                        if (!userRecord.ContainsKey(username))
                        {
                            userRecord[username] = new KeyValuePair<int, int>(0, 1);
                        }
                        else
                        {
                            KeyValuePair<int, int> userValues = userRecord[username];
                            int currLikes = userValues.Key;
                            int currComments = userValues.Value;
                            currComments += 1;
                            userRecord[username] = new KeyValuePair<int, int> (currLikes, currComments);
                        }
                        break;

                    case "Blocked":
                        if (!userRecord.ContainsKey(username))
                        {
                            Console.WriteLine($"{username} doesn't exist.");
                        }
                        else
                        {
                            userRecord.Remove(username);
                        }
                        break;

                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{userRecord.Count} followers");
            foreach (var user in userRecord)
            {
                KeyValuePair<int, int> curValues = user.Value;
                int sum = curValues.Key + curValues.Value;
                Console.WriteLine($"{user.Key}: {sum}");
            }
        }
    }
}
