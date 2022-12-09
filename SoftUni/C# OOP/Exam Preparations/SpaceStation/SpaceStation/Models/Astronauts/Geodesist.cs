using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double OXYGET_UNITS = 50;

        public Geodesist(string name) : base(name, OXYGET_UNITS)
        {
        }
    }
}
