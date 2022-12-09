using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double OXYGEN_UNITS = 70;

        public Biologist(string name) : base(name, OXYGEN_UNITS)
        {
        }

        public override void Breath()
        {
            double oxygenLeft = Oxygen - 5;
            if (oxygenLeft > 0)
            {
                this.Oxygen -= 5;
            }
            else
            {
                this.Oxygen = 0;
            }
        }
    }
}
