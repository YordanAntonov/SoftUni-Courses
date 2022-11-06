using ExplicitInterfaces.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces.Models
{
    public class Citizen : IResident, IPerson
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; private set; }

        public string Country { get; private set; }

        public int Age { get; private set; }

        string IResident.GetName()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Mr/Ms/Mrs {this.Name}");

            return sb.ToString().Trim();
        }

        string IPerson.GetName()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name}");
 
            return sb.ToString().Trim();
        }
    }
}
