using System;
using System.Collections.Generic;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight, livingRegion, breed)
        {
        }

        public override ICollection<Type> PreferredFoods => new HashSet<Type>() {typeof(Meat)};
    }
}
