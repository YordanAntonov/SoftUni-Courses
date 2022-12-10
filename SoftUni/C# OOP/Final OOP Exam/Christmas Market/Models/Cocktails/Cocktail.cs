using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private string name;
        private double price;
        protected Cocktail(string cocktailName, string size, double price)
        {
            this.Name = cocktailName;
            this.Size = size;
            this.Price = price;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                name = value;
            }
        }

        public string Size { get; private set; }

        public double Price
        {
            get { return price; }
            private set
            {
                double sizePrice = 0;
                if (this.Size == "Large")
                {
                    sizePrice = value;
                }
                else if (this.Size == "Middle")
                {
                    sizePrice = (value / 3) * 2;
                }
                else
                {
                    sizePrice = (value / 3) * 1;
                }

                price = sizePrice;
            }
        }

        public override string ToString() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.Size}) - {this.Price:f2} lv");

            return sb.ToString().Trim();
        }

    }
}
