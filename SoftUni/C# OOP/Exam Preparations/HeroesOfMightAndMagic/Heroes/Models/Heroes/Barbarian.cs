using Heroes.Models.Contracts;

namespace Heroes.Models.Heroes
{
    public class Barbarian : Hero, IHero
    {
        public Barbarian(string name, int health, int armour) : base(name, health, armour)
        {
        }
    }
}
