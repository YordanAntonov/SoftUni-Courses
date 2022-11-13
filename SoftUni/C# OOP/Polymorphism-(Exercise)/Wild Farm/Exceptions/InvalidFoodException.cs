using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Exceptions
{
    public class InvalidFoodException : Exception
    {
        private const string DefaulthFoodExceptionMessage = "Invalid food type!";

        public InvalidFoodException() : base(DefaulthFoodExceptionMessage)
        {

        }

        public InvalidFoodException(string value) : base(value)
        {

        }
    }
}
