using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Inheritance_Exercise
{
    public class Soldier
    {
        private int rage = 0;

        public Soldier()
        {

        }
        public Soldier(string name, int age)
        {
            Name = name;

            Health = 100;

            Age = age;

        }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Age { get; set; }

        public int Rage { get; set; }



        public virtual void BattleCry()
        {
            Rage += 50;
            Console.WriteLine($"I am a soldieeeer!!! My NAMEEEEE IS {Name} and Iam your Worst Nightmare!");
        }

        public virtual void Atack(string enemy)
        {
            Rage += 20;
            Console.WriteLine($"{Name} atacked {enemy} with slicing sword atack");
        }

        public virtual Soldier DeathCharge()
        {
            if (Rage >= 100)
            {
                Console.WriteLine("Aaaaaaaaarrg Take this you little shit, i will die for my cause!!!");
                Rage -= 100;
                Health -= 100;
                if (Health < 1)
                {
                    Console.WriteLine("This strong person died in battle!");
                }
                return this;
            }
            {
                Console.WriteLine("Not enough rage!");
                return null;
            }
          
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Soldier name: {Name}");
            sb.AppendLine($"{Name} died at the age of {Age}.");
            sb.AppendLine($"He had honorable death.");
            string result = sb.ToString().Trim();

            return result;
        }
    }
}
