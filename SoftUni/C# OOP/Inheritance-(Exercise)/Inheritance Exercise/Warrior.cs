using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance_Exercise
{
    public class Warrior : Soldier
    {
        public Warrior(string name, int age, string meleeWeapon) : base(name, age)
        {
            Health += 50;

            MeleeWeapon = meleeWeapon;
        }

        public string MeleeWeapon { get; set; }

        public override void Atack(string enemy)
        {
            Rage += 30;
            if (MeleeWeapon.ToLower() == "mace" || MeleeWeapon.ToLower() == "hammer")
            {

                Console.WriteLine($"{Name} atacked {enemy} with smashing {MeleeWeapon} atack! Brain spills everywhere!");
            }
            else
            {

                Console.WriteLine($"{Name} atacked {enemy} with vicious slicing {MeleeWeapon} atack! Blood splat everywhere!");
            }
        }

        public override void BattleCry()
        {
            Rage += 50;
            Console.WriteLine($"I am a Warriorr!!! My NAMEEEEE IS {Name} and Iam your Worst Nightmare!");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Warrior name: {Name}");
            sb.AppendLine($"{Name} died at the age of {Age}.");
            sb.AppendLine($"He had honorable death.");
            string result = sb.ToString().Trim();

            return result;
        }
    }
}
