
namespace SpaceStation.Core
{
    using SpaceStation.Core.Contracts;
    using SpaceStation.Models.Astronauts;
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Models.Mission;
    using SpaceStation.Models.Mission.Contracts;
    using SpaceStation.Models.Planets;
    using SpaceStation.Models.Planets.Contracts;
    using SpaceStation.Repositories;
    using SpaceStation.Repositories.Contracts;
    using SpaceStation.Utilities.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Controller : IController
    {
        private IRepository<IAstronaut> spaceStation;
        private IRepository<IPlanet> planets;
        private int exploredPlanets = 0;
        public Controller()
        {
            spaceStation = new AstronautRepository();
            planets = new PlanetRepository();
        }
        public string AddAstronaut(string type, string astronautName)
        {
            if (type != nameof(Biologist) && type != nameof(Meteorologist) && type != nameof(Geodesist))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            IAstronaut currAustro = null;
            switch (type)
            {
                case nameof(Biologist):
                    currAustro = new Biologist(astronautName);
                    break;
                case nameof(Meteorologist):
                    currAustro = new Meteorologist(astronautName);
                    break;
                case nameof(Geodesist):
                    currAustro = new Geodesist(astronautName);
                    break;
                default:
                    return null;
            }
            spaceStation.Add(currAustro);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            if (items.Any())
            {
                for (int i = 0; i < items.Length; i++)
                {
                    planet.Items.Add(items[i]);
                }
            }

            planets.Add(planet);

            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            IPlanet currPlanet = planets.FindByName(planetName);
            ICollection<IAstronaut> astronautsWithOxygen = spaceStation.Models.Where(a => a.Oxygen >= 60).ToList();
            IMission mission = new Mission();
            if (astronautsWithOxygen.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            if (astronautsWithOxygen.Any(a => a.CanBreath))
            {
                mission.Explore(currPlanet, astronautsWithOxygen);
                exploredPlanets++;
                planets.Remove(currPlanet);
                return string.Format(OutputMessages.PlanetExplored, planetName, astronautsWithOxygen.Count(a => !a.CanBreath));
            }

            return null;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astro in spaceStation.Models)
            {
                sb.AppendLine($"Name: {astro.Name}");
                sb.AppendLine($"Oxygen: {astro.Oxygen}");
                sb.Append("Bag items: ");
                sb.AppendLine(astro.Bag.Items.Any() ? string.Join(", ", astro.Bag.Items) : "none");
            }

            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut currAsto = spaceStation.FindByName(astronautName);
            if (currAsto == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            bool isRetired = spaceStation.Remove(currAsto);
            if (isRetired)
            {
                return String.Format(OutputMessages.AstronautRetired, astronautName);
            }
            return null;
        }
    }
}
