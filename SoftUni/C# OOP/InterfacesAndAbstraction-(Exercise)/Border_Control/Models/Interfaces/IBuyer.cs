using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control.Models.Interfaces
{
    public interface IBuyer
    {
        public int Food { get; }

        int BuyFood();
    }
}
