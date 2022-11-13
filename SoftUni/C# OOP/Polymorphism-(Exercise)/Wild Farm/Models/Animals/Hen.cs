using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize) : base(name, weight, wingSize)
        {
        }

        public override ICollection<Type> PreferredFoods => new HashSet<Type>() {typeof(Seeds), typeof(Vegetable), typeof(Meat), typeof(Fruit)};
    }
}
