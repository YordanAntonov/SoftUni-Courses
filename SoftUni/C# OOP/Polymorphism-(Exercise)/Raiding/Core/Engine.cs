
namespace Raiding.Core
{
    using Raiding.Core.Interfaces;
    using Raiding.Exceptions;
    using Raiding.Factories.Interfaces;
    using Raiding.IO.Interfaces;
    using Raiding.Models.Interfaces;
    using System.Collections.Generic;
    using System.Text;
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;

        private readonly ICollection<IBaseHero> heroes;
        public Engine()
        {
            this.heroes = new HashSet<IBaseHero>();
        }

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory) : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
        }

        public void Run()
        {
            int n = int.Parse(reader.ReadLine());
            int partyCount = 0;

            
            while (partyCount < n)
            {
                try
                {
                    this.heroes.Add(this.CreateHeroWithFactory());
                    partyCount++;
                }
                catch (InvalidHeroException ih)
                {
                    writer.WriteLine(ih.Message);
                }
            }

            writer.WriteLine(this.RaidTheBoss());
        
        }

        private IBaseHero CreateHeroWithFactory()
        {
            IBaseHero hero;
            string heroName = reader.ReadLine();
            string heroType = reader.ReadLine();

            hero = heroFactory.CreateHero(heroType, heroName);

            return hero;
        }

        private string RaidTheBoss()
        {
            int bossPower = int.Parse(reader.ReadLine());
            int totalHeroPower = 0;
            StringBuilder sb = new StringBuilder();

            foreach (IBaseHero hero in heroes)
            {
                totalHeroPower += hero.Power;
                sb.AppendLine(hero.CastAbility());
            }

            if (totalHeroPower >= bossPower)
            {
                sb.AppendLine("Victory!");
            }
            else
            {
                sb.AppendLine("Defeat...");
            }

            return sb.ToString().Trim();
        }
    }
}
