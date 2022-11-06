using Military_Elite.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Corps { get; }
    }
}
