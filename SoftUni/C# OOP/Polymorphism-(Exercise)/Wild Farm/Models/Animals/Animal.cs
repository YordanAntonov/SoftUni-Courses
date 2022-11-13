using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private Dictionary<string, string> animalSounds = new Dictionary<string, string>()
        {
            {"Owl", "Hoot Hoot"},
            {"Hen", "Cluck"},
            {"Mouse", "Squeak"},
            {"Dog", "Woof!"},
            {"Cat", "Meow"},
            {"Tiger", "ROAR!!!" }
        };
        private Dictionary<string, double> animalWeightMultipliers = new Dictionary<string, double>()
        {
            {"Owl", 0.25},
            {"Hen", 0.35},
            {"Mouse", 0.10},
            {"Dog", 0.40},
            {"Cat", 0.30},
            {"Tiger", 1.00 }
        };

        protected Animal(string name, double weight)
        {
            Name= name;
            Weight= weight;
            FoodEaten = 0;
        }
        
        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract ICollection<Type> PreferredFoods { get;}


        public void Eat(IFood food)
        {
            if (!this.PreferredFoods.Any(t => t.Name == food.GetType().Name))
            {
                throw new FoodNotEatenException(string.Format(ExceptionMessages.FoodNotEaten, this.GetType().Name, food.GetType().Name));
            }

            Weight += food.Quantity * animalWeightMultipliers[this.GetType().Name];
            FoodEaten += food.Quantity;
        }

        public virtual string ProduceSound()
        {
            return $"{animalSounds[this.GetType().Name]}";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}
