using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double defaultArmor = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed) : base(name, mainWeaponCaliber, speed, defaultArmor)
        {

        }
        public bool SonarMode { get; private set; }

        public override void RepairVessel()
        {
            if (this.ArmorThickness < defaultArmor)
            {
                this.ArmorThickness = defaultArmor;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {(SonarMode ? "ON" : "OFF")}");

            return sb.ToString().TrimEnd();
        }

        public void ToggleSonarMode()
        {
            if (!this.SonarMode)
            {
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }

            this.SonarMode = !this.SonarMode;
        }
    }
}
