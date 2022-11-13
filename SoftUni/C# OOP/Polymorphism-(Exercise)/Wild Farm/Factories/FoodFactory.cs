using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using WildFarm.Exceptions;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Food;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood CreateFood(string foodType, int quantity)
        {
            IFood food;

            switch (foodType)
            {
                case "Vegetable":
                    food = new Vegetable(quantity);
                    break;

                case "Meat":
                    food = new Meat(quantity);
                    break;

                case "Fruit":
                    food = new Fruit(quantity);
                    break;

                case "Seeds":
                    food = new Seeds(quantity);
                    break;
                default:
                    throw new InvalidFoodException();    
            }

            return food;
        }
    }
}
