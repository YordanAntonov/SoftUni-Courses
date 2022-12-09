using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budged;
        private UnitRepository units;
        private WeaponRepository weapons;
        public Planet()
        {
            units = new UnitRepository();
            weapons = new WeaponRepository();
        }
        public Planet(string name, double budged) : this()
        {
            Name = name;
            Budget = budged;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
                }
                name = value;
            }
        }

        public double Budget
        {
            get { return budged; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);
                }
                budged = value;
            }
        }

        public double MilitaryPower => Math.Round(MilitaryPowerCalculator(), 3);

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        private double MilitaryPowerCalculator()
        {
            double result = this.units.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel);

            if (this.units.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                result *= 1.3;
            }
            if (this.weapons.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                result *= 1.45;
            }

            return result;
        }
        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {Math.Round(Budget, 2)} billion QUID");
            sb.Append($"--Forces: ");

            if (units.Models.Count == 0) 
            {
                sb.AppendLine("No units");
            }
            else
            {
                Queue<string> units = new Queue<string>();
                foreach (var unit in this.Army)
                {
                    units.Enqueue(unit.GetType().Name);
                }

                sb.AppendLine(string.Join(", ", units));
            }

            sb.Append("--Combat equipment: ");

            if (weapons.Models.Count == 0)
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                Queue<string> weapons = new Queue<string>();
                foreach (var weapon in Weapons)
                {
                    weapons.Enqueue(weapon.GetType().Name);
                }
                sb.AppendLine(string.Join(", ", weapons));
            }

            sb.AppendLine($"--Military Power: {MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            this.Budget += amount;
        }

        public void Spend(double amount)
        {
            double futureAmount = Budget - amount;
            if (futureAmount < 0) 
            {
                throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach (var unit in this.Army)
            {
                unit.IncreaseEndurance();
            }
        }
    }
}
