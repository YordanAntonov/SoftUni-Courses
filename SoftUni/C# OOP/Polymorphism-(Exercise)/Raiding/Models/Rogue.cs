
namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int power = 80;
        public Rogue(string heroName) : base(heroName, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.HeroName} hit for {this.Power} damage";
        }
    }
}
