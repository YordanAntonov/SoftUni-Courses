using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_Exercise
{
    public class Archer : Soldier
    {
        public Archer(string name, int age, string bowType) : base(name, age)
        {
            BowType = bowType;

            Ammo = 10;

            Health -= 20;
        }

        public string BowType { get; set; }
        public int Ammo { get; set; }


        public void Shoot()
        {
            if (Ammo > 0)
            {
                Console.WriteLine($"{Name} shoots an arrow");
                Ammo--;
            }
            else
            {
                Console.WriteLine("I'm out of ammo!");
                Console.WriteLine("I will have to go and take new ones.");
                Console.Beep();
                Reload();
            }
        }

        public override void BattleCry()
        {
            Console.WriteLine("I will drink from your skull after im finished with you!!!");
        }
        public override void Atack(string enemy)
        {
            Shoot();
            Console.WriteLine($"{enemy} was hit by {BowType} arrow, he is bleeding heavily! Good grace..");
            Rage += 10;
        }

        public void Reload()
        {
            Ammo += 10;
            Console.WriteLine("Good grace i took new arrows!");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Archer name: {Name}");
            sb.AppendLine($"{Name} died at the age of {Age}.");
            sb.AppendLine("Fell from the castle walls while defending.");
            sb.AppendLine($"He had honorable death.");
            string result = sb.ToString().Trim();

            return result;
        }
    }
}
