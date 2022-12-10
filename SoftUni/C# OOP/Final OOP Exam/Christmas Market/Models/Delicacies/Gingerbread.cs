using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        private const double CONSTANT_PRICE = 4.00;
        public Gingerbread(string delicacyName) : base(delicacyName, CONSTANT_PRICE)
        {
        }
    }
}
