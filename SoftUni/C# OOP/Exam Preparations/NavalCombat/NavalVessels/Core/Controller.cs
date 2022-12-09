using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace NavalVessels.Core
{
    public class Controller : IController
    {
        private ICollection<ICaptain> captains;
        private VesselRepository vessels;

        public Controller()
        {
            captains = new HashSet<ICaptain>();
            vessels = new VesselRepository();
        }


        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            if (vesselType != nameof(Battleship) && vesselType != nameof(Submarine))
            {
                return OutputMessages.InvalidVesselType;
            }

            IVessel currVessel = vessels.FindByName(name);

            if (currVessel != null)
            {
                return String.Format(OutputMessages.VesselIsAlreadyManufactured, vesselType, name);
            }


            switch (vesselType)
            {
                case nameof(Battleship):
                    currVessel = new Battleship(name, mainWeaponCaliber, speed);
                    break;
                case nameof(Submarine):
                    currVessel = new Submarine(name, mainWeaponCaliber, speed);
                    break;
            }

            vessels.Add(currVessel);
            return String.Format(OutputMessages.SuccessfullyCreateVessel, vesselType, name, mainWeaponCaliber, speed);
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain currCap = captains.FirstOrDefault(c => c.FullName == selectedCaptainName);
            IVessel currVessel = vessels.FindByName(selectedVesselName);
            if (currCap == null)
            {
                return String.Format(OutputMessages.CaptainNotFound, selectedCaptainName);
            }

            if (currVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, selectedVesselName);
            }

            if (currVessel.Captain != null)
            {
                return String.Format(OutputMessages.VesselOccupied, selectedVesselName);
            }


            currVessel.Captain = currCap;
            currCap.AddVessel(currVessel);
            return String.Format(OutputMessages.SuccessfullyAssignCaptain, selectedCaptainName, selectedVesselName);
        }

        public string HireCaptain(string fullName)
        {
            ICaptain curCap = captains.FirstOrDefault(c => c.FullName == fullName);

            if (curCap != null)
            {
                return String.Format(OutputMessages.CaptainIsAlreadyHired, fullName);
            }

            curCap = new Captain(fullName);
            captains.Add(curCap);
            return String.Format(OutputMessages.SuccessfullyAddedCaptain, fullName);
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel currVessel = vessels.FindByName(vesselName);
            if (currVessel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            currVessel.RepairVessel();
            return string.Format(OutputMessages.SuccessfullyRepairVessel, vesselName);
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel currVesel = vessels.FindByName(vesselName);
            if (currVesel == null)
            {
                return string.Format(OutputMessages.VesselNotFound, vesselName);
            }

            if (currVesel.GetType().Name == nameof(Battleship))
            {
                Battleship bs = (Battleship)currVesel;
                bs.ToggleSonarMode();
                return String.Format(OutputMessages.ToggleBattleshipSonarMode, vesselName);
            }
            else
            {
                Submarine sm = (Submarine)currVesel;
                sm.ToggleSubmergeMode();
                return String.Format(OutputMessages.ToggleSubmarineSubmergeMode, vesselName);
            }
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel atackVessel = vessels.FindByName(attackingVesselName);
            IVessel defVessel = vessels.FindByName(defendingVesselName);

            if (atackVessel == null && defVessel == null)
            {
                
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            else if (atackVessel== null)
            {
                return String.Format(OutputMessages.VesselNotFound, attackingVesselName);
            }
            else if (defVessel == null)
            {
                return String.Format(OutputMessages.VesselNotFound, defendingVesselName);
            }

            if (atackVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, attackingVesselName);
            }

            if (defVessel.ArmorThickness == 0)
            {
                return String.Format(OutputMessages.AttackVesselArmorThicknessZero, defendingVesselName);
            }

            atackVessel.Attack(defVessel);
            atackVessel.Captain.IncreaseCombatExperience();
            defVessel.Captain.IncreaseCombatExperience();
            return String.Format(OutputMessages.SuccessfullyAttackVessel, defendingVesselName, attackingVesselName, defVessel.ArmorThickness);
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain currCap = captains.FirstOrDefault(c => c.FullName == captainFullName);
            return currCap.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel currVessel = vessels.FindByName(vesselName);
            return currVessel.ToString();
        }
    }
}
