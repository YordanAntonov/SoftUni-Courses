namespace Raiding.Models
{
    using Interfaces;
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string heroName, int power)
        {
            HeroName = heroName;
            Power = power;
        }
        public string HeroName { get; private set; }

        public int Power { get; private set; }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.HeroName} healed for {this.Power}"; // For Paladin and Druid
        }
    }

}
