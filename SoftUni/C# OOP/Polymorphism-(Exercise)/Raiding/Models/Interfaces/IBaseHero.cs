
namespace Raiding.Models.Interfaces
{

    public interface IBaseHero
    {
        public string HeroName { get; }

        public int Power { get; }

        string CastAbility();
    }
}
