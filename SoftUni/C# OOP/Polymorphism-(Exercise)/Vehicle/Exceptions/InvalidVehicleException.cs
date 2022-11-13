using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Exceptions
{
    public class InvalidVehicleException : Exception
    {
        private const string DefaulthMessage = "Vehicle type not supported";
        public InvalidVehicleException() : base(DefaulthMessage)
        {

        }

        public InvalidVehicleException(string text) : base(text)
        {

        }
    }
}
