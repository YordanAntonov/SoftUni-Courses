using Military_Elite.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models.Contracts
{
    public interface IMission
    {
        public string CodeName { get; }
        public State State { get; }

        void CompleteMission();
    }
}
