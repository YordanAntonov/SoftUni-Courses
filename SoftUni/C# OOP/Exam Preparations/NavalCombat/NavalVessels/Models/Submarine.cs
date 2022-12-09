using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double defaultArmor = 200;
        public Submarine(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, defaultArmor)
        {
        }

        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < defaultArmor)
            {
                this.ArmorThickness = defaultArmor;
            }
        }

        public void ToggleSubmergeMode()
        {
            if (!this.SubmergeMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 4;
            }

            this.SubmergeMode = !this.SubmergeMode;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }
    }
}
