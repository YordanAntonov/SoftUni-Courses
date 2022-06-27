using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendListMaintanance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> friendsList = Console.ReadLine().Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string command = "";
            int blackListCounter = 0;
            int lostNames = 0;

            while ((command = Console.ReadLine()) != "Report")
            {
                string[] tokens = command.Split(' ');

                if (tokens[0] == "Blacklist")
                {
                    string name = tokens[1];
                    bool isNameInTheList = friendsList.Contains(name);


                    if (isNameInTheList)
                    {
                        blackListCounter++;
                        Console.WriteLine($"{name} was blacklisted.");
                        for (int i = 0; i < tokens.Length; i++)
                        {
                            if (friendsList[i] == name)
                            {
                                friendsList[i] = "Blacklisted";
                                break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"{name} was not found.");
                    }

                }
                else if (tokens[0] == "Error")
                {
                    int index = int.Parse(tokens[1]);
                    if (index < 0 || index > friendsList.Count - 1) // index not valid
                    {
                        continue;
                    }
                    string username = friendsList[index];

                    if (username != "Blacklisted" && username != "Lost")
                    {
                        Console.WriteLine($"{username} was lost due to an error.");
                        friendsList[index] = "Lost";
                        lostNames++;
                    }
                    else
                    {
                        continue;
                    }

                }
                else if (tokens[0] == "Change")
                {
                    int index = int.Parse(tokens[1]);
                    string newUser = tokens[2];
                    if (index < 0 || index > friendsList.Count - 1) // index not valid
                    {
                        continue;
                    }
                    else
                    {
                        string currName = friendsList[index];
                        friendsList[index] = newUser;
                        Console.WriteLine($"{currName} changed his username to {newUser}.");
                    }               
                }
            }
            Console.WriteLine($"Blacklisted names: {blackListCounter}");
            Console.WriteLine($"Lost names: {lostNames}");
            Console.WriteLine(string.Join(" ", friendsList));
        }
    }
}
