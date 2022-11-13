using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle.Exceptions
{
    public class TankOverflowException : Exception
    {
        private const string DefaulthExceptionMessage = "Cannot fit {0} fuel in the tank";

        public TankOverflowException() : base(DefaulthExceptionMessage)
        {

        }

        public TankOverflowException(string text) : base(text) 
        {

        }
    }
}
