using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamWork_Projects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int numberOfTeams = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfTeams; i++)
            {
                string[] teamAndCreator = Console.ReadLine().Split('-');
                string teamName = teamAndCreator[1];
                string creator = teamAndCreator[0];

                if (teams.Any(team => team.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }
                else if (teams.Any(team => team.Creator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else
                {
                    List<string> newMembers = new List<string>();
                    Team team = new Team(teamName, creator, newMembers);
                    teams.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
            }
            string command = "";

            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] candidates = command.Split(new[] {"->"}, StringSplitOptions.RemoveEmptyEntries);
                string candidateName = candidates[0];
                string joiningTeam = candidates[1];

                if (teams.All(team => team.TeamName != joiningTeam))
                {
                    Console.WriteLine($"Team {joiningTeam} does not exist!");
                }
                else if (teams.Any(team => team.Members.Contains(candidateName)) || teams.Any(creator => creator.Creator == candidateName))
                {
                    Console.WriteLine($"Member {candidateName} cannot join team {joiningTeam}!");
                }
                else
                {
                    var currentTeam = teams.Find(team => team.TeamName == joiningTeam);
                    currentTeam.Members.Add(candidateName);
                }

            }
            List<Team> disbandedTeam = teams.Where(s => s.Members.Count == 0).ToList();

            List<Team> validTeams = teams.Where(g => g.Members.Count > 0).ToList();

            foreach (Team team in validTeams.OrderByDescending(x => x.Members.Count).ThenBy(n => n.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
                Console.WriteLine($"- {team.Creator}");
                foreach (var member in team.Members.OrderBy(x=>x))
                {
                    Console.WriteLine($"-- {member}");
                }
            }

            Console.WriteLine($"Teams to disband:");
            foreach  (Team team in disbandedTeam.OrderBy(x=>x.TeamName))
            {
                Console.WriteLine($"{team.TeamName}");
            }
        }
    }

    class Team
    {

        public Team(string teamName, string creator, List<string> members)
        {
            TeamName = teamName;
            Creator = creator;
            Members = members;

        }


        public string TeamName { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }
    }
}
