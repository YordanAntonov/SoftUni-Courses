using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Football_Team_Generator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Team> teams = new HashSet<Team>();



            string command = Console.ReadLine();

            while (command != "END")
            {
                try
                {

                    string[] cmdArgs = command.Split(";");

                    string action = cmdArgs[0];
                    string teamName = cmdArgs[1];

                    switch (action)
                    {
                        case "Team":
                            Team team = new Team(teamName);
                            teams.Add(team);
                            break;

                        case "Add":
                            string playerName = cmdArgs[2];
                            if (!teams.Any(t => t.Name == teamName))
                            {
                                throw new Exception(String.Format(ExceptionMessages.INVALID_TEAM, teamName));
                            }

                            Team currTeam = teams.FirstOrDefault(t => t.Name == teamName);

                            currTeam.Add(playerName, int.Parse(cmdArgs[3]), int.Parse(cmdArgs[4]), int.Parse(cmdArgs[5]), int.Parse(cmdArgs[6]), int.Parse(cmdArgs[7]));
                            break;

                        case "Remove":
                            string removePlayer = cmdArgs[2];
                            if (!teams.Any(t => t.Name == teamName))
                            {
                                throw new Exception(String.Format(ExceptionMessages.INVALID_TEAM, teamName));
                            }

                            Team curTeam = teams.FirstOrDefault(t => t.Name == teamName);
                            curTeam.RemovePlayer(removePlayer, teamName);
                            break;

                        case "Rating":
                            if (!teams.Any(t => t.Name == teamName))
                            {
                                throw new Exception(String.Format(ExceptionMessages.INVALID_TEAM, teamName));
                            }

                            Team thisTeam = teams.FirstOrDefault(t => t.Name == teamName);

                            Console.WriteLine($"{thisTeam.Name} - {thisTeam.Rating()}");
                            break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                    command = Console.ReadLine();
            }
        }

    }

}

