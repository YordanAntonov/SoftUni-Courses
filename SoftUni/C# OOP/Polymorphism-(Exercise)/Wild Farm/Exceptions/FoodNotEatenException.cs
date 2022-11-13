using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Exceptions
{
    public class FoodNotEatenException : Exception
    {     
        public FoodNotEatenException(string value) : base(value)
        {

        }
    }
}
