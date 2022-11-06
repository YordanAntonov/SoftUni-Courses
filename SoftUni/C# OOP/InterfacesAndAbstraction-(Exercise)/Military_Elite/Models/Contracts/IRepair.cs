using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite.Models.Contracts
{
    public interface IRepair
    {
        public string PartName { get; }
        public int HoursWorked { get; }
    }
}
