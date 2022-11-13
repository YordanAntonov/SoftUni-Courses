using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int power = 100;
        public Paladin(string heroName) : base(heroName, power)
        {
        }
    }
}
