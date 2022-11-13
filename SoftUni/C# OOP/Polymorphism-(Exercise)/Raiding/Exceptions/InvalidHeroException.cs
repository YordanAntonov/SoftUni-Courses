using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Exceptions
{
    public class InvalidHeroException : Exception
    {
        private const string InvalidHero = "Invalid hero!";
        public InvalidHeroException() : base(InvalidHero)
        {

        }

        public InvalidHeroException(string message) : base(message) 
        {

        }
    }
}
