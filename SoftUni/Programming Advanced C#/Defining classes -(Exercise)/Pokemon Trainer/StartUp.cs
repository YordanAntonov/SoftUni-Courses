using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            HashSet<Trainer> trainers = new HashSet<Trainer>();

            string command = Console.ReadLine();

            while (command != "Tournament")
            {
                string[] info = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                GetTrainerAndPokemon(info, trainers);

                command = Console.ReadLine();
            }

            string commandTwo = Console.ReadLine();



            while (commandTwo != "End")
            {
                string requestedElement = commandTwo;

                foreach (var trainer in trainers)
                {
                    bool doesNotHave = true;
                    foreach (var pokemon in trainer.PokemonCollection)
                    {
                        if (pokemon.Element == requestedElement)
                        {
                            doesNotHave = false;
                            trainer.NumberOfBadges++;
                            break;
                        }
                    }

                    if (doesNotHave && trainer.PokemonCollection.Count > 0)
                    {
                        trainer.PokemonCollection.ForEach(p => p.Health -= 10);
                        trainer.PokemonCollection.RemoveAll(pokemon => pokemon.Health <= 0);
                    }
                }

                commandTwo = Console.ReadLine();
            }

            HashSet<Trainer> sortedTrainers = trainers.OrderByDescending(t => t.NumberOfBadges).ToHashSet();
            foreach (var trainer in sortedTrainers)
            {
                Console.WriteLine(trainer.ToString());
            }
        }

        private static void GetTrainerAndPokemon(string[] info, HashSet<Trainer> trainers)
        {
            string trainerName = info[0];
            string pokemonName = info[1];
            string pokemonElement = info[2];
            int pokemonHealth = int.Parse(info[3]);
            if (trainers.Any(t => t.Name == trainerName)) // Check for already existing trainer
            {
                Trainer trainer = trainers.FirstOrDefault(c => c.Name == trainerName);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainer.PokemonCollection.Add(pokemon);
            }
            else // If theres not, make him and add to the list
            {
                Trainer trainer = new Trainer(trainerName);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                trainer.PokemonCollection.Add(pokemon);
                trainers.Add(trainer);
            }
        }
    }
}
