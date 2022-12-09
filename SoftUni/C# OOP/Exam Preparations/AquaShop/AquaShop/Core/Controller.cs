using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Repositories.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private IRepository<IDecoration> decorations;
        private List<IAquarium> aquariums;

        public Controller()
        {
            decorations = new DecorationRepository();
            aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            if (aquariumType != nameof(SaltwaterAquarium) && aquariumType != nameof(FreshwaterAquarium))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);
            }

            IAquarium aquarium;
            switch (aquariumType)
            {
                case nameof(SaltwaterAquarium):
                    aquarium = new SaltwaterAquarium(aquariumName);
                    break;

                case nameof(FreshwaterAquarium):
                    aquarium = new FreshwaterAquarium(aquariumName);
                    break;

                default:
                    return null;
            }

            aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if (decorationType != nameof(Ornament) && decorationType != nameof(Plant))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);
            }

            IDecoration decoration;
            switch (decorationType)
            {
                case nameof(Ornament):
                    decoration = new Ornament();
                    break;

                case nameof(Plant):
                    decoration = new Plant();
                    break;

                default:
                    return null;
            }

            decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            if (fishType != nameof(FreshwaterFish) && fishType != nameof(SaltwaterFish))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidFishType);
            }

            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);


            if ((fishType == nameof(FreshwaterFish) && aquarium.GetType().Name == nameof(SaltwaterAquarium)) || (fishType == nameof(SaltwaterFish) &&
                aquarium.GetType().Name == nameof(FreshwaterAquarium)))
            {
                return string.Format(OutputMessages.UnsuitableWater);
            }

            IFish fish;
            switch (fishType)
            {
                case nameof(FreshwaterFish):
                    fish = new FreshwaterFish(fishName, fishSpecies, price);
                    break;
                case nameof(SaltwaterFish):
                    fish = new SaltwaterFish(fishName, fishSpecies, price);
                    break;
                default:
                    return null;
            }

            aquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
        }

        public string CalculateValue(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            decimal totalValue = aquarium.Fish.Sum(f => f.Price) + aquarium.Decorations.Sum(d => d.Price);

            return string.Format(OutputMessages.AquariumValue, aquariumName, Math.Round(totalValue, 2));
        }

        public string FeedFish(string aquariumName)
        {
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);
            aquarium.Feed();
            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            //If Succesful remove decoration from the repository;
            IDecoration decoration = decorations.FindByType(decorationType);
            IAquarium aquarium = aquariums.FirstOrDefault(a => a.Name == aquariumName);

            if (decoration == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration, decorationType));
            }

            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var aquarium in aquariums)
            {
                sb.AppendLine(aquarium.GetInfo());
            }

            return sb.ToString().Trim();
        }
    }
}
