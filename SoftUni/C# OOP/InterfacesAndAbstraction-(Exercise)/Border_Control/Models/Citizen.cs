
namespace Border_Control.Models
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using Models.Interfaces;

    public class Citizen :  ICitizen, IBirthdate, IBuyer
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            NameOrModel = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = 0;
        }

        public string NameOrModel { get; private set; }
        public string Id { get; private set; }
        public int Age { get; private set; }
        public string Birthdate { get; private set; }
        public int Food { get; private set; }


        public int BuyFood()
        {
            Food += 10;
            return 10;
        }
    }
}
