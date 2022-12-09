using Heroes.Models.Contracts;
namespace Heroes.Models.Heroes
{
    public class Knight : Hero, IHero
    {
        public Knight(string name, int health, int armour) : base(name, health, armour)
        {
        }
    }
}
