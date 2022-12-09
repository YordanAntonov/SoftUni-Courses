using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            //ICollection<IAstronaut> astronautsWithOxygen = astronauts.Where(a => a.CanBreath).ToList();

            foreach (var astronaut in astronauts)
            {
                if (astronaut.CanBreath)
                {
                    foreach (var item in planet.Items)
                    {
                        if (astronaut.CanBreath == false)
                        {
                            break;
                        }
                        
                        astronaut.Breath();
                        astronaut.Bag.Items.Add(item);
                    }

                    foreach (var item in astronaut.Bag.Items)
                    {
                        planet.Items.Remove(item);
                    }

                }
            }

        }
    }
}
