using Raiding.Exceptions;
using Raiding.Factories.Interfaces;
using Raiding.Models;
using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Raiding.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IBaseHero CreateHero(string type, string name)
        {
            IBaseHero hero;

            switch (type)
            {
                case "Druid":
                    hero = new Druid(name);
                    break;
                case "Paladin":
                    hero = new Paladin(name);
                    break;
                case "Rogue":
                    hero = new Rogue(name);
                    break;
                case "Warrior":
                    hero= new Warrior(name);
                    break;
                default:
                    throw new InvalidHeroException();  
            }

            return hero;
        }
    }
}
