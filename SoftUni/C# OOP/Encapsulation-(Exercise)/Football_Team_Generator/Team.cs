using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Football_Team_Generator
{
    public class Team
    {
        private string name;
        private HashSet<Player> players;

        public Team()
        {
            players = new HashSet<Player>();
        }

        public Team(string name) : this()
        {
            Name = name;
        }
        public string Name
        {
            get { return name; }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_NAME));
                }

                name = value;
            }
        }

        public void Add(string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);

            this.players.Add(player);

        }

        public void RemovePlayer(string playerName, string teamName)
        {

            if (!this.players.Any(p => p.Name == playerName))
            {
                throw new Exception(string.Format(ExceptionMessages.INVALID_PLAYER, playerName, teamName));
            }

            Player currPlayer = players.FirstOrDefault(P => P.Name == playerName);

            this.players.Remove(currPlayer);
        }

        public double Rating()
        {
            if (players.Count == 0)
            {
                return 0;
            }
            double result = players.Average(p => p.Stats.OverallStats());

            return Math.Round(result);
        }
    }
}
