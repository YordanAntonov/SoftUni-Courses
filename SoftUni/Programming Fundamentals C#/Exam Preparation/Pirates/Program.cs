using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pirates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, KeyValuePair<long, long>> cities = new Dictionary<string, KeyValuePair<long, long>>();
            List<string> cityNames = new List<string>();
            string command = Console.ReadLine();

            while (command != "Sail")
            {
                string[] tokens = command.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                string cityName = tokens[0];
                long population = long.Parse(tokens[1]);
                long gold = long.Parse(tokens[2]);

                if (!cities.ContainsKey(cityName))
                {
                    cities[cityName] = new KeyValuePair<long, long>(population, gold);
                    cityNames.Add(cityName);
                }
                else
                {
                    KeyValuePair<long, long> currValues = cities[cityName];
                    long currPop = currValues.Key + population;
                    long currGold = currValues.Value + gold;
                    cities[cityName] = new KeyValuePair<long, long>(currPop, currGold);
                }
                command = Console.ReadLine();
            }

            string secondCommand = Console.ReadLine();

            while (secondCommand != "End")
            {
                string[] tokens = secondCommand.Split(new[] { "=>" }, StringSplitOptions.RemoveEmptyEntries);
                string action = tokens[0];
                string cityName = tokens[1];
                KeyValuePair<long, long> currentPopAndGold = cities[cityName];
                long currentPopulation = currentPopAndGold.Key;
                long currGold = currentPopAndGold.Value;

                switch (action)
                {
                    case "Plunder":
                        if (cities.ContainsKey(cityName))
                        {
                            long people = long.Parse(tokens[2]);
                            long gold = long.Parse(tokens[3]);
                            currentPopulation -= people;
                            currGold -= gold;
                            Console.WriteLine($"{cityName} plundered! {gold} gold stolen, {people} citizens killed.");

                            if (currGold <= 0 || currentPopulation <= 0)
                            {
                                Console.WriteLine($"{cityName} has been wiped off the map!");
                                cities.Remove(cityName);
                                cityNames.Remove(cityName);
                            }
                            else
                            {
                                cities[cityName] = new KeyValuePair<long, long>(currentPopulation, currGold);
                            }
                        }
                        else
                        {
                            secondCommand = Console.ReadLine();
                            continue;
                        }
                        break;

                    case "Prosper":
                        long addedGold = long.Parse(tokens[2]);

                        if (addedGold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            secondCommand = Console.ReadLine();
                            continue;
                        }
                        else
                        {
                            currGold += addedGold;
                            Console.WriteLine($"{addedGold} gold added to the city treasury. {cityName} now has {currGold} gold.");
                            cities[cityName] = new KeyValuePair<long, long>(currentPopulation, currGold);
                        }
                        break;
                }
                secondCommand = Console.ReadLine();
            }

            if (cities.Count <= 0)
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            else 
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (var cityName in cityNames)
                {
                    Console.WriteLine($"{cityName} -> Population: {cities[cityName].Key} citizens, Gold: {cities[cityName].Value} kg");
                }
            }
        }


    }
}
