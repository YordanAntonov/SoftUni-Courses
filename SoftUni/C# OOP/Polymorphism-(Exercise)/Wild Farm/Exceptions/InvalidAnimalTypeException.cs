using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace WildFarm.Exceptions
{
    public class InvalidAnimalTypeException : Exception
    {
        private const string DefaulthInvalidAnimal = "Invalid animal type!";

        public InvalidAnimalTypeException() : base(DefaulthInvalidAnimal)
        {

        }
        public InvalidAnimalTypeException(string value) : base(value)
        {

        }
    }
}
