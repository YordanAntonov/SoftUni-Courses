using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFE_MILLILITERS = 50;
        private const decimal COFFE_PRICE = 3.50m;
        
        public Coffee(string name, double caffeine) : base(name,COFFE_PRICE, COFFE_MILLILITERS)
        {
            Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
