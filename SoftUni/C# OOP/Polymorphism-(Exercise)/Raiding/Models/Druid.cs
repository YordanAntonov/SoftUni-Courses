using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int power = 80;
        public Druid(string heroName) : base(heroName, power)
        {
        }
    }
}
