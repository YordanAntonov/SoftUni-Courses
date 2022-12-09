using Heroes.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Heroes.Models.Weapons
{
    public class Claymore : Weapon, IWeapon
    {
        private const int WeaponDamage = 20;
        public Claymore(string name, int durability) : base(name, durability)
        {
        }

        public override int DoDamage()
        {
            if (this.Durability > 0)
            {
                Durability -= 1;
            }
            if (this.Durability == 0)
            {
                return 0;
            }

            return WeaponDamage;
        }
    }
}
