
using System.Collections.Generic;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Mammal : Animal 
    {
        public Mammal(string name, double weight, string livingRegion) : base(name, weight)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
