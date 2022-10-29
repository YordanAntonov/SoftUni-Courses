using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double GRAMS = 250;
        private const decimal PRICE = 5;
        private const double CALORIES = 1000;
        public Cake(string name) : base(name, PRICE, GRAMS, CALORIES)
        {
        }
    }
}
