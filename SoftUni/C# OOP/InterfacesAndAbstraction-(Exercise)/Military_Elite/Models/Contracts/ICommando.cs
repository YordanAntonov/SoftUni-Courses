using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models.Contracts
{
    public interface ICommando : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IMission> Missions { get; }
    }
}
