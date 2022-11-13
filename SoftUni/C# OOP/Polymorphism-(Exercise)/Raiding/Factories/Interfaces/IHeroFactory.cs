using Raiding.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories.Interfaces
{
    public interface IHeroFactory
    {
        IBaseHero CreateHero(string type, string name);
    }
}
