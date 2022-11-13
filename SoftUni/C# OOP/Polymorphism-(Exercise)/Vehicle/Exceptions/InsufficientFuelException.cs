using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Exceptions
{
    public class InsufficientFuelException : Exception
    {
        public InsufficientFuelException(string message) : base(message)
        {

        }
        
    }
}
