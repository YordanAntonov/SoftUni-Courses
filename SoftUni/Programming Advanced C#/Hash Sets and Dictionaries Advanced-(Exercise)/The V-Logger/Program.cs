using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_V_Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Vloggers> vLoggerList = new List<Vloggers>();

            string command = Console.ReadLine();

            while (command != "Statistics")
            {
                string[] tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string vloggerName = tokens[0];
                string action = tokens[1];
                bool isFollowed = false;

                if (action == "joined")
                {
                    if (!vLoggerList.Any(x => x.Name == vloggerName))
                    {
                        Vloggers vlogger = new Vloggers(vloggerName);
                        vLoggerList.Add(vlogger);
                    }
                }
                else if (action == "followed")
                {
                    string followedVlogger = tokens[2];
                    if (vLoggerList.Any(x => x.Name == followedVlogger) && vLoggerList.Any(c => c.Name == vloggerName))
                    {
                        Vloggers vlogger = vLoggerList.First(x => x.Name == vloggerName);
                        if (vloggerName != followedVlogger && !(vlogger.Following.Contains(followedVlogger)))
                        {
                            vlogger.Following.Add(followedVlogger);
                            isFollowed = true;
                        }
                    }
                    if (isFollowed)
                    {
                        Vloggers vlogger = vLoggerList.First(x => x.Name == followedVlogger);
                        if (!vlogger.Followers.Contains(vloggerName))
                        {
                            vlogger.Followers.Add(vloggerName);
                        }
                    }
                }
                command = Console.ReadLine();
            }
            vLoggerList = vLoggerList.OrderByDescending(x => x.Followers.Count).ThenBy(c => c.Following.Count).ToList();
            int counter = 1;
            Console.WriteLine($"The V-Logger has a total of {vLoggerList.Count} vloggers in its logs.");
            foreach (var vlogger in vLoggerList)
            {
                Console.WriteLine($"{counter}. {vlogger.Name} : {vlogger.Followers.Count} followers, {vlogger.Following.Count} following");
                if (counter == 1)
                {
                    foreach (var follower in vlogger.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                    counter++;
            }
        }
    }

    class Vloggers
    {
        public Vloggers(string name)
        {
            Name = name;

            Followers = new SortedSet<string>();

            Following = new HashSet<string>();
        }

        public string Name { get; set; }
        public SortedSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }
    }
}
