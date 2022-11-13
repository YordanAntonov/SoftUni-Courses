using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Exceptions
{
    public class FuelCannotBeNegativeException : Exception
    {
        private const string DefaulthExceptionMessage = "Fuel must be a positive number";
        public FuelCannotBeNegativeException() : base(DefaulthExceptionMessage)
        {

        }

        public FuelCannotBeNegativeException(string text) : base(text)
        {

        }
    }
}
