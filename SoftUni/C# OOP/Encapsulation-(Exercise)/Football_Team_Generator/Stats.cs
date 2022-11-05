using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Team_Generator
{
    public class Stats
    {
        private const int MIN_STAT_VALUE = 0;
        private const int MAX_STAT_VALUE = 100;

        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;

            Sprint = sprint;

            Dribble = dribble;

            Passing = passing;

            Shooting = shooting;
        }

        public int Endurance
        {
            get { return endurance; }

            private set
            {
                if (value < MIN_STAT_VALUE || value > MAX_STAT_VALUE)
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_STATS_RANGE, nameof(this.Endurance)));
                }

                endurance = value;
            }
        }

        public int Sprint
        {
            get { return sprint; }

            private set
            {
                if (value < MIN_STAT_VALUE || value > MAX_STAT_VALUE)
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_STATS_RANGE, nameof(this.Sprint)));
                }

                sprint = value;
            }
        }

        public int Dribble
        {
            get { return dribble; }

            private set
            {
                if (value < MIN_STAT_VALUE || value > MAX_STAT_VALUE)
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_STATS_RANGE, nameof(this.Dribble)));
                }

                dribble = value;
            }
        }

        public int Passing
        {
            get { return passing; }

            private set
            {
                if (value < MIN_STAT_VALUE || value > MAX_STAT_VALUE)
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_STATS_RANGE, nameof(this.Passing)));
                }

                passing = value;
            }
        }

        public int Shooting
        {
            get { return shooting; }

            private set
            {
                if (value < MIN_STAT_VALUE || value > MAX_STAT_VALUE)
                {
                    throw new Exception(string.Format(ExceptionMessages.INVALID_STATS_RANGE, nameof(this.Shooting)));
                }

                shooting = value;
            }
        }
        public double OverallStats() => (Endurance + Sprint + Dribble + Passing + Shooting) / (double)5;
       
    }
}
