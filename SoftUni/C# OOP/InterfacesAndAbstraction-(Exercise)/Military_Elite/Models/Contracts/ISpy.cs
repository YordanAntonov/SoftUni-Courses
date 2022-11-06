using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models.Contracts
{
    public interface ISpy : ISoldier
    {
        public int CodeNumber { get; }
    }
}
