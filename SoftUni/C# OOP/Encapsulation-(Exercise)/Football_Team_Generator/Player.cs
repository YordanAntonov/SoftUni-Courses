using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Team_Generator
{
    public class Player
    {
        private string name;


        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;

            Stats = new Stats(endurance, sprint, dribble, passing, shooting);
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

        public Stats Stats { get; private set; }

    }
}
