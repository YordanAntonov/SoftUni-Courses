using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Fish
{
    public class SaltwaterFish : Fish
    {
        //Can only live in SaltwaterAquarium!
        private const int INITIAL_SIZE = 5;

        public SaltwaterFish(string name, string species, decimal price) : base(name, species, price)
        {
            this.Size = INITIAL_SIZE;
        }

        public override void Eat()
        {
            this.Size += 2;
        }
    }
}
