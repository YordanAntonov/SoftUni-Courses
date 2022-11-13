
namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int power = 100;
        public Warrior(string heroName) : base(heroName, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.HeroName} hit for {this.Power} damage";
        }
    }
}
