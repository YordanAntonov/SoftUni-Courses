using PlanetWars.Core.Contracts;
using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Linq;
using System.Text;


namespace PlanetWars.Core
{
    public class Controller : IController
    {
        private PlanetRepository planets;

        public Controller()
        {
            planets = new PlanetRepository();
        }


        public string AddUnit(string unitTypeName, string planetName)
        {
            if (planets.FindByName(planetName) == null)
            {
                return String.Format(ExceptionMessages.UnexistingPlanet, planetName);
            }

            if (unitTypeName != nameof(AnonymousImpactUnit) && unitTypeName != nameof(StormTroopers) && unitTypeName != nameof(SpaceForces))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));
            }

            IPlanet planet = planets.FindByName(planetName);

            if (planet.Army.Any(s => s.GetType().Name == unitTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            }
            IMilitaryUnit unit;
            if (unitTypeName == nameof(StormTroopers))
            {
                unit = new StormTroopers();
            }
            else if (unitTypeName == nameof(SpaceForces))
            {
                unit = new SpaceForces();
            }
            else
            {
                unit = new AnonymousImpactUnit();
            }
            planet.Spend(unit.Cost);
            planet.AddUnit(unit);
            return String.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            if (planets.FindByName(planetName) == null)
            {
                return String.Format(ExceptionMessages.UnexistingPlanet, planetName);
            }

            IPlanet planet = planets.FindByName(planetName);

            if (planet.Weapons.Any(w => w.GetType().Name == weaponTypeName))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            }

            if (weaponTypeName != nameof(NuclearWeapon) && weaponTypeName != nameof(SpaceMissiles) && weaponTypeName != nameof(BioChemicalWeapon))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));
            }

            IWeapon weapon;
            if (weaponTypeName == nameof(BioChemicalWeapon))
            {
                weapon = new BioChemicalWeapon(destructionLevel);
            }
            else if (weaponTypeName == nameof(NuclearWeapon))
            {
                weapon = new NuclearWeapon(destructionLevel);
            }
            else
            {
                weapon = new SpaceMissiles(destructionLevel);
            }
            planet.Spend(weapon.Price);
            planet.AddWeapon(weapon);
            return String.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string CreatePlanet(string name, double budget)
        {

            if (planets.FindByName(name) != null)
            {
                return String.Format(OutputMessages.ExistingPlanet, name);
            }

            IPlanet planet = new Planet(name, budget);
            planets.AddItem(planet);
            return String.Format(OutputMessages.NewPlanet, name);
        }

        public string ForcesReport()
        {
            var orderedPlanets = planets.Models.OrderByDescending(p => p.MilitaryPower).ThenBy(p => p.Name).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            foreach (var planet in orderedPlanets)
            {
                sb.AppendLine(planet.PlanetInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            IPlanet firstPlanet = planets.FindByName(planetOne);
            IPlanet secondPlanet = planets.FindByName(planetTwo);

            IPlanet winnerPlanet;
            IPlanet losingPlanet;

            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower) // IF THEY HAVE THR SAME POWER LEVEL
            {
                IWeapon firstPlanetNuclear = firstPlanet.Weapons.FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));
                IWeapon SecondPlanetNuclear = secondPlanet.Weapons.FirstOrDefault(w => w.GetType().Name == nameof(NuclearWeapon));

                if ((firstPlanetNuclear != null && SecondPlanetNuclear != null) || (firstPlanetNuclear == null && SecondPlanetNuclear == null))
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return OutputMessages.NoWinner;
                }

                if (firstPlanetNuclear != null && SecondPlanetNuclear == null)
                {
                    winnerPlanet = firstPlanet;
                    losingPlanet = secondPlanet;
                }
                else
                {
                    winnerPlanet = secondPlanet;
                    losingPlanet = firstPlanet;
                }
            }
            else
            {
                if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
                {
                    winnerPlanet = firstPlanet;
                    losingPlanet = secondPlanet;
                }
                else
                {
                    winnerPlanet = secondPlanet;
                    losingPlanet = firstPlanet;
                }
            }

            winnerPlanet.Spend(winnerPlanet.Budget / 2);
            winnerPlanet.Profit(losingPlanet.Budget / 2);

            double winnings = losingPlanet.Army.Sum(s => s.Cost) + losingPlanet.Weapons.Sum(w => w.Price);
            winnerPlanet.Profit(winnings);

            planets.RemoveItem(losingPlanet.Name);

            return String.Format(OutputMessages.WinnigTheWar, winnerPlanet.Name, losingPlanet.Name);


        }

        public string SpecializeForces(string planetName)
        {
            IPlanet planet = planets.FindByName(planetName);

            if (planet == null)
            {
                return String.Format(ExceptionMessages.UnexistingPlanet, planetName);
            }

            if (planet.Army.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            }
            double trainingCost = 1.25;
            planet.Spend(trainingCost);
            planet.TrainArmy();
            return String.Format(OutputMessages.ForcesUpgraded, planetName);
        }
    }
}
