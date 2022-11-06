using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        public IReadOnlyCollection<IRepair> Repairs { get; }
    }
}
