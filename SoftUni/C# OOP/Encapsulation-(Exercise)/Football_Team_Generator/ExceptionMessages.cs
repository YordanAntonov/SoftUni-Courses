using System;
using System.Collections.Generic;
using System.Text;

namespace Football_Team_Generator
{
    public static class ExceptionMessages
    {
        public const string INVALID_NAME = "A name should not be empty.";
        public const string INVALID_STATS_RANGE = "{0} should be between 0 and 100.";
        public const string INVALID_PLAYER = "Player {0} is not in {1} team.";
        public const string INVALID_TEAM = "Team {0} does not exist.";
    }
}
