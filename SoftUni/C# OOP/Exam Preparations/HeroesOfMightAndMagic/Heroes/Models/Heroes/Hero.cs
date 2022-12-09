using Heroes.Models.Contracts;
using System;
using System.Text;

namespace Heroes.Models.Heroes
{
    public abstract class Hero : IHero
    {
        private string name;
        private int health;
        private int armour;
        private IWeapon weapon;

        protected Hero(string name, int health, int armour)
        {
            Name = name;
            Health = health;
            Armour = armour;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hero name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Health
        {
            get { return health; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero health cannot be below 0.");
                }
                health = value;
            }
        }

        public int Armour
        {
            get { return armour; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hero armour cannot be below 0.");
                }
                armour = value;
            }
        }

        public IWeapon Weapon
        {
            get { return weapon; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Weapon cannot be null.");
                }
                weapon = value;
            }
        }

        public bool IsAlive => Health > 0;


        public void AddWeapon(IWeapon weapon)
        {
            if (weapon != null)
            {
                if (this.Weapon == null)
                {
                    this.Weapon = weapon;
                }
            }
        }

        public void TakeDamage(int points)
        {
            int expectedHealth = Health - points;
            int expectedArmor = Armour - points;

            if (expectedArmor >= 0)
            {
                this.Armour -= points;
            }
            else
            {
                int penetrationArmor = Math.Abs(this.Armour - points);
                this.Armour = 0;
                if (expectedHealth <= 0)
                {
                    this.Health = 0;
                }
                else
                {
                    this.Health -= penetrationArmor;
                }
            }

        }

        public override string ToString()
        {
            string weapon = this.Weapon != null ? $"{this.Weapon.Name}" : "Unarmed";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}: {this.Name}");
            sb.AppendLine($"--Health: {this.Health}");
            sb.AppendLine($"--Armour: {this.Armour}");
            sb.AppendLine($"--Weapon: {weapon}");

            return sb.ToString().TrimEnd();
        }
    }
}
