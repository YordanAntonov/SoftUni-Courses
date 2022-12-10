using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public class MulledWine : Cocktail
    {
        private const double CONST_PRICE = 13.50;
        public MulledWine(string cocktailName, string size) : base(cocktailName, size, CONST_PRICE)
        {
        }
    }
}
