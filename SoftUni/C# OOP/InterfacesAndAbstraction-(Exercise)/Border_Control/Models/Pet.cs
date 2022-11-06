using Border_Control.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Border_Control.Models
{
    public class Pet : IBirthdate
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; private set; }
        public string Birthdate { get; private set; }
    }
}
